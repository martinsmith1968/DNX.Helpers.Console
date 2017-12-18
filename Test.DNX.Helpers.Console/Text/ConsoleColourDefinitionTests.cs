using System;
using DNX.Helpers.Console;
using DNX.Helpers.Console.Enums;
using NUnit.Framework;

namespace Test.DNX.Helpers.Console.Text
{
    [TestFixture]
    public class ConsoleColourDefinitionTests
    {
        [TestCase(ConsoleColor.Red, ColorType.Foreground, ExpectedResult = "Foreground:Red")]
        [TestCase(ConsoleColor.Green, ColorType.Foreground, ExpectedResult = "Foreground:Green")]
        [TestCase(ConsoleColor.Blue, ColorType.Background, ExpectedResult = "Background:Blue")]
        public string ConsoleColourDefinition_ToText_Successful_Test(ConsoleColor consoleColor, ColorType colorType)
        {
            var result = new ConsoleColourDefinition(consoleColor, colorType);

            return result.ToText();
        }

        [TestCase("Red", ExpectedResult = "Foreground:Red")]
        [TestCase("Foreground:Green", ExpectedResult = "Foreground:Green")]
        [TestCase("Background:Blue", ExpectedResult = "Background:Blue")]
        public string ConsoleColourDefinition_FromText_Successful_Test(string colourAndType)
        {
            var result = ConsoleColourDefinition.FromText(colourAndType);

            return result.ToText();
        }
    }
}
