using System;
using System.IO;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Console.Modifiers;

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
            using (var colourChanger = ColourChanger.Create(Colour, ColourType))
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
            using (var colourChanger = ColourChanger.Create(Colour, ColourType))
            {
                textWriter.WriteLine(Text);
            }
        }
    }
}
