using System;
using System.IO;
using System.Linq;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Console.Modifiers;
using DNX.Helpers.Strings;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class ColouredText.
    /// </summary>
    public class ColouredText : IConsoleText
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public IConsoleText Text { get; private set; }

        /// <summary>
        /// Gets the colour changer.
        /// </summary>
        /// <value>The colour changer.</value>
        public ConsoleColor Colour { get; private set; }

        /// <summary>
        /// Gets the type of the colour.
        /// </summary>
        /// <value>The type of the colour.</value>
        public ColorType ColourType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColouredText" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="colour">The colour.</param>
        /// <param name="colourType">Type of the colour.</param>
        public ColouredText(string text, ConsoleColor colour, ColorType colourType)
            : this(new PlainText(text), colour, colourType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColouredText"/> class.
        /// </summary>
        /// <param name="consoleText">The console text.</param>
        /// <param name="colour">The colour.</param>
        /// <param name="colorType">Type of the color.</param>
        public ColouredText(IConsoleText consoleText, ConsoleColor colour, ColorType colorType)
        {
            Text       = consoleText;
            Colour     = colour;
            ColourType = colorType;
        }

        /// <summary>
        /// Writes the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void Write(TextWriter textWriter)
        {
            using (var colourChanger = ColourChangerHelper.Create(Colour, ColourType))
            {
                textWriter.Write(Text);
            }
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void WriteLine(TextWriter textWriter)
        {
            using (var colourChanger = ColourChangerHelper.Create(Colour, ColourType))
            {
                textWriter.WriteLine(Text);
            }
        }

        /// <summary>
        /// Determines whether this instance can parse the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if this instance can parse the specified text; otherwise, <c>false</c>.</returns>
        public static bool CanParse(string text)
        {
            return !string.IsNullOrEmpty(text)
                   && text.StartsWith("[[");
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ColouredText.</returns>
        public static ColouredText Parse(ref string text)
        {
            if (!CanParse(text))
            {
                return null;
            }

            var colouredTextIdent = text.ParseFirstMatchToDictionary(@"\[\[(?<ident>[^\]]+)\]\]");
            if (!colouredTextIdent.ContainsKey("ident") || string.IsNullOrEmpty(colouredTextIdent["ident"]))
            {
                return null;
            }

            var ident = colouredTextIdent["ident"];

            var startText = string.Format("[[{0}]]", ident);
            var endText   = string.Format("[[/{0}]]", ident);
            var innerText = text.Between(startText, endText);

            var colourAndType = ParseColourAndType(ident);

            // TODO: If InnerText contains [[...]] then recurse using text after startText before continuing

            var instance = new ColouredText(innerText, colourAndType.Item1, colourAndType.Item2);

            text = text.RemoveStartsWith(string.Concat(startText, innerText, endText));

            return instance;
        }

        /// <summary>
        /// Parses the type of the colour and.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Tuple&lt;ConsoleColor, ColorType&gt;.</returns>
        public static Tuple<ConsoleColor, ColorType> ParseColourAndType(string text)
        {
            var parts = text.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var colourText = parts.Last();
            var colourTypeText = parts.Length > 1
                ? parts.First()
                : ColorType.Foreground.ToString();

            ConsoleColor colour;
            ColorType colourType;

            if (!Enum.TryParse(colourText, out colour))
            {
                throw new Exception(string.Format("Invalid Console Colour: {0}", colourText));
            }
            if (!Enum.TryParse(colourTypeText, out colourType))
            {
                throw new Exception(string.Format("Invalid Colour Type: {0}", colourTypeText));
            }

            return new Tuple<ConsoleColor, ColorType>(colour, colourType);
        }
    }
}
