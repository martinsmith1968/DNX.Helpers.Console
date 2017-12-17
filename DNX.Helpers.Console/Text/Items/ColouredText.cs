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
                Text.Write(textWriter);
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
                   && text.StartsWith(ConsoleTextHelper.MarkerTagStart)
                   && ConsoleColourDefinition.FromText(ConsoleTextHelper.GetNextMarkerIdent(text)) != null;
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

            var ident = ConsoleTextHelper.GetNextMarkerIdent(text);

            var colourDefinition = ConsoleColourDefinition.FromText(ident);

            text = text.RemoveStartMarkerByIdent(ident);

            var innerText = ConsoleTextHelper.Parse(ref text, ident);

            var instance = new ColouredText(innerText, colourDefinition.Colour, colourDefinition.ColourType);

            text = text.RemoveEndMarkerByIdent(ident);

            return instance;
        }
    }
}
