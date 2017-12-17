using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Console;
using DNX.Helpers.Console.Modifiers;
using DNX.Helpers.Console.Text;
using DNX.Helpers.Linq;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Test.DNX.Helpers.Console;

namespace Test.DNX.Helpers.ConsoleApp
{
    internal class Program
    {
        private static TextWriter _textWriter;

        private static int Main()
        {
            _textWriter = System.Console.Out;

            var colouredText1 = "Program.exe [[Yellow]]v1.0[[/Yellow]] - [[Blue]]Description[[/Blue]].";
            var colouredText2 = "[[Yellow]]2017-12-16 [[Red]]Error:[[/Red]] MethodName:[[/Yellow]] Message Text";

            colouredText1.ToConsoleText().WriteLine(_textWriter);
            colouredText2.ToConsoleText().WriteLine(_textWriter);

            TestRunner.TestRunnerType = TestRunnerType.Console;

            var runResults = RunTestsInAllAssemblies();
            ShowSummary(runResults);

            var failures = GetTestFailures(runResults);
            ShowFailures(failures);

            var returnCode = failures.HasAny()
                ? failures.Count
                : 0;

            if (System.Diagnostics.Debugger.IsAttached)
            {
                _textWriter.WriteLine();
                ConsoleHelper.ClearInputKeys();
                _textWriter.Pause(TimeSpan.FromSeconds(30));
            }

            return returnCode;
        }

        private static void ShowFailures(IList<TestMethodResult> failures)
        {
            if (!failures.HasAny())
            {
                return;
            }

            var failuresByAssemblyAndType = failures
                .GroupBy(f => f.Method.DeclaringType.Namespace)
                .ToDictionary(t => t.Key, t => t.GroupBy(m => m.Method.DeclaringType)
                    .ToDictionary(x => x.Key, x => x.ToList())
                );

            foreach (var failingAssembly in failuresByAssemblyAndType)
            {
                _textWriter.WriteLine("{0}", failingAssembly.Key);

                foreach (var failingType in failingAssembly.Value)
                {
                    _textWriter.WriteLine("  {0}",
                        failingType.Key.FullName.RemoveStartsWith(failingAssembly.Key).RemoveStartsWith("."));

                    foreach (var failure in failures)
                    {
                        ShowResult(failure, "    ");
                    }
                }
            }
        }

        private static List<TestMethodResult> GetTestFailures(IList<TestMethodResult> runResults)
        {
            var failures = runResults
                .Where(r => r.ResultType == ResultType.Failed)
                .ToList();
            return failures;
        }

        private static void ShowSummary(IEnumerable<TestMethodResult> runResults)
        {
            var resultsByResultType = runResults
                .GroupBy(r => r.ResultType)
                .ToDictionary(g => g.Key, g => g.ToList());

            _textWriter.WriteLine();
            _textWriter.WriteLine("Summary");
            _textWriter.WriteLine("=======");

            using (var colourChanger = new ForegroundColourChanger(ConsoleColor.White))
            {
                foreach (var kvp in resultsByResultType)
                {
                    switch (kvp.Key)
                    {
                        case ResultType.Succeeded:
                            colourChanger.ChangeColour(ConsoleColor.Green);
                            break;
                        case ResultType.Failed:
                            colourChanger.ChangeColour(ConsoleColor.Red);
                            break;
                        case ResultType.Ignored:
                            colourChanger.ChangeColour(ConsoleColor.Yellow);
                            break;
                    }

                    _textWriter.WriteLine("{0}: {1} tests", kvp.Key, kvp.Value.Count);
                }
            }
        }

        private static void ShowResult(TestMethodResult testMethodResult, string prefix = null)
        {
            System.Console.WriteLine("{0}{1}.{2}: {3}",
                prefix,
                testMethodResult.Method.DeclaringType.FullName,
                testMethodResult.Method.Name,
                testMethodResult.Message
                );
        }

        private static List<TestMethodResult> RunTestsInAllAssemblies()
        {
            var assemblies = GetLoadedAssemblies();

            var runResults = new List<TestMethodResult>();

            foreach (var assembly in assemblies)
            {
                var assemblyResults = RunTestsInAssembly(assembly);

                if (assemblyResults != null)
                {
                    runResults.AddRange(assemblyResults);
                }
            }
            return runResults;
        }

        private static IEnumerable<TestMethodResult> RunTestsInAssembly(Assembly assembly)
        {
            var testTypes = GetTestTypes(assembly);

            var assemblyResults = new List<TestMethodResult>();

            foreach (var testType in testTypes)
            {
                var typeResults = RunTestsInType(testType);

                if (typeResults != null)
                {
                    assemblyResults.AddRange(typeResults);
                }
            }

            return assemblyResults;
        }

        private static IEnumerable<TestMethodResult> RunTestsInType(Type testType)
        {
            var testMethods = GetTestMethods(testType)
                .ToList();

            if (!testMethods.HasAny())
            {
                return null;
            }

            _textWriter.WriteLine();
            _textWriter.WriteLine(testType.FullName);

            var typeResults = new List<TestMethodResult>();

            var fixtureSetup    = GetMethodWithAttribute<OneTimeSetUpAttribute>(testType);
            var fixtureTeardown = GetMethodWithAttribute<OneTimeTearDownAttribute>(testType);
            var testSetup       = GetMethodWithAttribute<SetUpAttribute>(testType);
            var testTeardown    = GetMethodWithAttribute<TearDownAttribute>(testType);

            var testInstance = testType.CreateDefaultInstance();

            if (fixtureSetup != null)
            {
                fixtureSetup.Invoke(testInstance, null);
            }

            foreach (var testMethod in testMethods)
            {
                var result = RunTestMethod(testInstance, testMethod, testSetup, testTeardown);

                typeResults.Add(result);
            }

            if (fixtureTeardown != null)
            {
                fixtureTeardown.Invoke(testInstance, null);
            }

            return typeResults;
        }

        private static TestMethodResult RunTestMethod(object testInstance, MethodInfo testMethod, MethodInfo testSetup, MethodInfo testTeardown)
        {
            if (testSetup != null)
            {
                testSetup.Invoke(testInstance, null);
            }

            try
            {
                _textWriter.WriteLine(testMethod.Name);
                testMethod.Invoke(testInstance, null);

                return TestMethodResult.Success(testMethod);

            }
            catch (Exception ex)
            {
                return TestMethodResult.Failure(testMethod, ex);
            }
            finally
            {
                if (testTeardown != null)
                {
                    testTeardown.Invoke(testInstance, null);
                }
            }
        }

        private static MethodInfo GetMethodWithAttribute<T>(Type testType)
        {
            var method = testType
                .GetMethods()
                .FirstOrDefault(m => m.GetMemberAttributes<T>(true).HasAny());

            return method;
        }

        private static IEnumerable<MethodInfo> GetTestMethods(Type testType)
        {
            var methods = testType
                .GetMethods()
                .Where(m => m.GetMemberAttributes<TestAttribute>(true).HasAny())
                .ToList();

            return methods;
        }

        private static IList<Type> GetTestTypes(Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetTypeAttributes<TestFixtureAttribute>(true).HasAny())
                .ToList();

            return types;
        }

        private static IEnumerable<Assembly> GetLoadedAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
