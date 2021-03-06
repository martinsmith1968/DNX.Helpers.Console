﻿using System;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Text.Items;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.Text.Items
{
    [TestFixture]
    public class ColouredTextItemTests
    {
        [Test]
        public void Parse_should_parse_a_simple_definition_successfully()
        {
            // Arrange
            var text = "[[Red]]This text is Red[[/Red]]";

            // Act
            var result = ColouredTextItem.Parse(ref text);

            // Assert
            text.ShouldBeNullOrEmpty();
            result.ShouldNotBeNull();
            result.Colour.ShouldBe(ConsoleColor.Red);
            result.ColourType.ShouldBe(ColorType.Foreground);
            result.Text.ShouldNotBeNull();

            var innerTextCollection = result.Text.ShouldBeOfType<TextItemCollection>();
            innerTextCollection.Parts.Count.ShouldBe(1);
            var plainText = innerTextCollection.Parts[0].ShouldBeOfType<PlainTextItem>();
            plainText.Text.ShouldBe("This text is Red");
        }

        [Test]
        public void Parse_should_parse_an_explicit_definition_successfully()
        {
            // Arrange
            var text = "[[Foreground:Red]]This text is Red[[/Foreground:Red]]";

            // Act
            var result = ColouredTextItem.Parse(ref text);

            // Assert
            text.ShouldBeNullOrEmpty();
            result.ShouldNotBeNull();
            result.Colour.ShouldBe(ConsoleColor.Red);
            result.ColourType.ShouldBe(ColorType.Foreground);
            result.Text.ShouldNotBeNull();

            var innerTextCollection = result.Text.ShouldBeOfType<TextItemCollection>();
            innerTextCollection.Parts.Count.ShouldBe(1);
            var plainText = innerTextCollection.Parts[0].ShouldBeOfType<PlainTextItem>();
            plainText.Text.ShouldBe("This text is Red");
        }

        [Test]
        public void Parse_should_parse_an_explicit_non_default_definition_successfully()
        {
            // Arrange
            var text = "[[Background:Red]]This text is Red[[/Background:Red]]";

            // Act
            var result = ColouredTextItem.Parse(ref text);

            // Assert
            text.ShouldBeNullOrEmpty();
            result.ShouldNotBeNull();
            result.Colour.ShouldBe(ConsoleColor.Red);
            result.ColourType.ShouldBe(ColorType.Background);
            result.Text.ShouldNotBeNull();

            var innerTextCollection = result.Text.ShouldBeOfType<TextItemCollection>();
            innerTextCollection.Parts.Count.ShouldBe(1);
            var plainText = innerTextCollection.Parts[0].ShouldBeOfType<PlainTextItem>();
            plainText.Text.ShouldBe("This text is Red");
        }
    }
}
