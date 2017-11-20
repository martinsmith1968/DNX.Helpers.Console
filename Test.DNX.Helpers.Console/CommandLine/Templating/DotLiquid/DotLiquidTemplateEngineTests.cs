using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Help;
using DNX.Helpers.Console.CommandLine.Templating.DotLiquid;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    internal class TestArguments
    {

    }

    [TestFixture]
    public class DotLiquidTemplateEngineTests
    {
        private DotLiquidTemplateEngine _templateEngine;

        [SetUp]
        public void TestInitialise()
        {
            _templateEngine = new DotLiquidTemplateEngine();
        }

        [Test]
        public void RenderTest()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());
            _templateEngine.AddObject("Program", assemblyDetails);

            var argumentsMap = ArgumentsMap.Create<TestArguments>();
            _templateEngine.AddObject("Arguments", argumentsMap);

            dynamic result = new ExpandoObject();
            result.Failed = true;
            result.Errors = new List<IDictionary<string, object>>()
            {
                new ParserError() {Message = "Invalid argument: -k"}.ToDictionary()
            };

            _templateEngine.AddObject("Result", result);

            // Act
            var resultLines = _templateEngine.Render(Templates.StandardTemplateLines);
            var resultText = string.Join(Environment.NewLine, resultLines);

            // Assert
            resultText.ShouldNotBeNullOrEmpty();
            resultText.Length.ShouldBeGreaterThan(0);

            //resultLines.Count.ShouldBe(Templates.StandardTemplateLines.Length - 1);
            //
            //resultLines.Skip(0).First().ShouldBe(string.Format("{0} v{1} - {2}", assemblyDetails.Title, assemblyDetails.SimplifiedVersion, assemblyDetails.Description));
            //resultLines.Skip(1).First().ShouldBe(string.Format("{0}", assemblyDetails.Copyright));
            //resultLines.Skip(2).First().ShouldBe("");
            //resultLines.Skip(3).First().ShouldBe("Usage:");
            //resultLines.Skip(4).First().ShouldBe(string.Format("{0}", assemblyDetails.FileName));
        }
    }
}
