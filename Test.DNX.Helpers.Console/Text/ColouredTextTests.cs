using System;
using DNX.Helpers.Console.Text;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.Text
{
    [TestFixture]
    public class ColouredTextTests
    {
        [Test]
        public void Parse()
        {
            // Arrange
            var text = "[[Red]]This text is Red[[/Red]]";

            // Act
            var result = ColouredText.Parse(ref text);

            // Assert
            text.ShouldBeNullOrEmpty();
            result.ShouldNotBeNull();
            result.Text.ShouldNotBeNull();

            var plainText = result.Text as PlainText;
            plainText.ShouldNotBeNull();
            plainText.Text.ShouldBe("This text is Red");
            result.Colour.ShouldBe(ConsoleColor.Red);
        }
    }
}
