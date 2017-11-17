using System;
using System.IO;
using System.Text;
using CommandLine;
using DNX.Helpers.Console.CommandLine;
using DNX.Helpers.Console.CommandLine.Help;
using DNX.Helpers.Console.Exceptions;
using NUnit.Framework;
using SampleApp;
using Shouldly;

namespace Test.DNX.Helpers.Console.Samples
{
    [TestFixture]
    public class ProgramSingleArgumentsClassTests
    {
        private StringBuilder _outputText;
        private StringWriter _outputStringWriter;

        private static int Main(string[] args, Action<Arguments> runAction, TextWriter outputWriter)
        {
            try
            {
                var result = ParserHelper.GetParserAndParse<Arguments>(args)
                    .WithParsed(runAction);

                return result.Ok() ? 0 : 1;
            }
            catch (ParserResultException<Arguments> ex)
            {
                var helpText = HelpBuilder.BuildTemplatedHelpText(ex.FailureResult);

                outputWriter.WriteLine(helpText);

                return 2;
            }
            catch (ReturnCodeException ex)
            {
                outputWriter.WriteLine(ex);

                return ex.ReturnCode;
            }
            catch (Exception ex)
            {
                outputWriter.WriteLine(ex);

                return ReturnCodeException.MaximumReturnCode;
            }
        }

        [SetUp]
        public void TestSetup()
        {
            _outputText = new StringBuilder();
            _outputStringWriter = new StringWriter(_outputText);
        }

        [Test]
        public void EmptyArguments_generates_help_page_successfully()
        {
            // Arrange
            var runCalled = false;
            var args = new string[] {};

            Action<Arguments> runAction = (arguments) =>
            {
                runCalled = true;
            };

            // Act
            var result = Main(args, runAction, _outputStringWriter);

            // Assert
            result.ShouldBe(2);
            runCalled.ShouldBeFalse();
            _outputText.Length.ShouldBeGreaterThan(0);
        }
    }
}
