using System;
using CommandLine;
using DNX.CommandLine.Helpers.Exceptions;
using NUnit.Framework;

namespace Test.DNX.Helpers.Console.Exceptions
{
    internal class Args
    {
        public string FileName { get; set; }
    }

    [TestFixture]
    public class ParserResultExceptionTests
    {
        [Test]
        public void ParserResultException_with_result()
        {
            // Arrange
            var args = "1 2".Split(' ');
            var result = Parser.Default.ParseArguments<Args>(args);

            // Act
            var ex = new ParserResultException<Args>(result);

            // Assert
            Assert.AreEqual(result, ex.Result);
        }

        [Test]
        public void ParserResultException_with_result_and_message()
        {
            // Arrange
            var args = "1 2".Split(' ');
            var result = Parser.Default.ParseArguments<Args>(args);
            var message = "This is an error";

            // Act
            var ex = new ParserResultException<Args>(result, message);

            // Assert
            Assert.AreEqual(result, ex.Result);
            Assert.AreEqual(message, ex.Message);
        }

        [Test]
        public void ParserResultException_with_result_and_message_and_inner_exception()
        {
            // Arrange
            var args = "1 2".Split(' ');
            var result = Parser.Default.ParseArguments<Args>(args);
            var message = "This is an error";
            var innerException = new Exception();

            // Act
            var ex = new ParserResultException<Args>(result, message, innerException);

            // Assert
            Assert.AreEqual(result, ex.Result);
            Assert.AreEqual(message, ex.Message);
            Assert.AreEqual(innerException, ex.InnerException);
        }
    }
}