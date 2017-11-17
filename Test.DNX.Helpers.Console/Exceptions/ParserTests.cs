﻿using CommandLine;
using DNX.Helpers.Console.CommandLine;
using DNX.Helpers.Console.Interfaces;
using NUnit.Framework;

namespace Test.DNX.Helpers.Console.Exceptions
{
    internal class Args : IParserSettingsCustomiser
    {
        [Value(0, Required = true)]
        public string FileName { get; set; }

        [Option('f', "flag", Default = false, HelpText = "Optional flag", Required = false)]
        public bool Flag { get; set; }

        public void CustomiseSettings(ParserSettings settings)
        {
            settings.ShouldThrowOnParseFailure(false);
        }
    }

    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void FailureResult_returned_by_Parser_Parse_for_invalid_arguments()
        {
            // Arrange
            var args = new string[] {};

            // Act
            var result = ParserHelper.GetParserAndParse<Args>(args);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Ok());
        }

        [Test]
        public void ParserResult_Success_with_required_values_set()
        {
            // Arrange
            var args = "bob.txt".Split(' ');

            // Act
            var result = ParserHelper.GetParserAndParse<Args>(args);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Ok());
            Assert.AreEqual("bob.txt", result.GetArguments().FileName);
            Assert.IsFalse(result.GetArguments().Flag);
        }

        [Test]
        public void ParserResult_Success_with_required_and_optional_values_set()
        {
            // Arrange
            var args = "bob.txt -f".Split(' ');

            // Act
            var result = ParserHelper.GetParserAndParse<Args>(args);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Ok());
            Assert.AreEqual("bob.txt", result.GetArguments().FileName);
            Assert.IsTrue(result.GetArguments().Flag);
        }
    }
}
