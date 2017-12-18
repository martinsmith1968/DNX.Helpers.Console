using System;
using System.Linq;
using System.Text;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Text;
using DNX.Helpers.Console.Text.Items;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.Text
{
    [TestFixture]
    public class ConsoleTextHelperTests
    {
        [Test]
        public static void Parse_can_detect_linear_parts()
        {
            // Arrange
            const string text = "Program.exe [[Yellow]]v1.0[[/Yellow]] - [[Blue]]Description[[/Blue]].";

            // Act
            var result = ConsoleTextHelper.Parse(text);

            // Assert
            result.ShouldNotBeNull();

            var collection = result as TextItemCollection;
            collection.ShouldNotBeNull();
            collection.Parts.Count.ShouldBe(5);

            var part0 = collection.Parts[0].ShouldBeOfType<PlainTextItem>();
            part0.Text.ShouldBe("Program.exe ");

            var part1 = collection.Parts[1].ShouldBeOfType<ColouredTextItem>();
            part1.Colour.ShouldBe(ConsoleColor.Yellow);
            part1.ColourType.ShouldBe(ColorType.Foreground);
            var part11 = part1.Text.ShouldBeOfType<TextItemCollection>();
            part11.Parts.Count.ShouldBe(1);
            var part110 = part11.Parts[0].ShouldBeOfType<PlainTextItem>();
            part110.Text.ShouldBe("v1.0");

            var part2 = collection.Parts[2].ShouldBeOfType<PlainTextItem>();
            part2.Text.ShouldBe(" - ");

            var part3 = collection.Parts[3].ShouldBeOfType<ColouredTextItem>();
            part3.Colour.ShouldBe(ConsoleColor.Blue);
            part3.ColourType.ShouldBe(ColorType.Foreground);
            var part31 = part3.Text.ShouldBeOfType<TextItemCollection>();
            part31.Parts.Count.ShouldBe(1);
            var part310 = part31.Parts[0].ShouldBeOfType<PlainTextItem>();
            part310.Text.ShouldBe("Description");

            var part4 = collection.Parts[4].ShouldBeOfType<PlainTextItem>();
            part4.Text.ShouldBe(".");
        }

        [Test]
        public static void Parse_can_detect_nested_ColouredText()
        {
            // Arrange
            const string text = "[[Yellow]]2017-12-16 [[Red]]Error:[[/Red]] MethodName:[[/Yellow]] Message Text";

            // Act
            var result = ConsoleTextHelper.Parse(text);

            // Assert
            result.ShouldNotBeNull();

            var collection = result as TextItemCollection;
            collection.ShouldNotBeNull();
            collection.Parts.Count.ShouldBe(2);

            var part0 = collection.Parts[0].ShouldBeOfType<ColouredTextItem>();
            part0.Colour.ShouldBe(ConsoleColor.Yellow);
            part0.ColourType.ShouldBe(ColorType.Foreground);

            var part01 = part0.Text.ShouldBeOfType<TextItemCollection>();
            part01.Parts.Count.ShouldBe(3);

            var part010 = part01.Parts[0].ShouldBeOfType<PlainTextItem>();
            part010.Text.ShouldBe("2017-12-16 ");

            var part011 = part01.Parts[1].ShouldBeOfType<ColouredTextItem>();
            part011.Colour.ShouldBe(ConsoleColor.Red);
            part011.ColourType.ShouldBe(ColorType.Foreground);

            var part012 = part01.Parts[2].ShouldBeOfType<PlainTextItem>();
            part012.Text.ShouldBe(" MethodName:");

            var part1 = collection.Parts[1].ShouldBeOfType<PlainTextItem>();
            part1.Text.ShouldBe(" Message Text");
        }

        [Test]
        public static void Parse_throws_Exception_on_badly_nested_items()
        {
            // Arrange
            const string text = "[[Yellow]]2017-12-16 [[Red]]Error:[[/Blue]] MethodName:[[/Yellow]] Message Text";

            // Act
            var ex = Should.Throw<Exception>(() => ConsoleTextHelper.Parse(text));

            // Assert
            ex.ShouldBeOfType<Exception>();
            ex.Message.ShouldContain("Red");
            ex.Message.ShouldContain("Blue");
        }

        [Test]
        public static void Parse_throws_Exception_on_badly_formed_ident()
        {
            // Arrange
            const string text =
                "[[Yellow]]2017-12-16 [[Middleground:Red]]Error:[[/Blue]] MethodName:[[/Yellow]] Message Text";

            // Act
            var ex = Should.Throw<Exception>(() => ConsoleTextHelper.Parse(text));

            // Assert
            ex.ShouldBeOfType<Exception>();
            ex.Message.ShouldContain("Middleground:Red");
        }

        [Test]
        public void ConsoleText_random_test()
        {
            // Arrange
            var lineCount = Faker.RandomNumber.Next(25, 50);
            var colourNames = Enum.GetNames(typeof(ConsoleColor));

            var lines = Enumerable.Range(0, lineCount)
                .Select(x =>
                {
                    var wordCount = Faker.RandomNumber.Next(5, 10);

                    var line = new StringBuilder();
                    line.AppendFormat("{0} ({1}): ", x, wordCount);

                    for (var i=0; i < wordCount; ++i)
                    {
                        var colour = colourNames[Faker.RandomNumber.Next(0, colourNames.Length - 1)];

                        if (line.Length > 0)
                            line.Append(" ");

                        line.AppendFormat("[[{0}]]{0}[[/{0}]]", colour);
                    }

                    return line;
                });

            // Act
            foreach (var line in lines)
            {
                var consoleText = line.ToString().ToConsoleText();

                consoleText.WriteLine(System.Console.Out);
            }

            // Assert
            lineCount.ShouldBeGreaterThan(0);
        }

    }
}
