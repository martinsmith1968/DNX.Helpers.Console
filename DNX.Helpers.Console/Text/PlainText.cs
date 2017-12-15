using System.IO;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class RawText.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleText" />
    public class PlainText : IConsoleText
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainText"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public PlainText(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Writes the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void Write(TextWriter textWriter)
        {
            textWriter.Write(Text);
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void WriteLine(TextWriter textWriter)
        {
            textWriter.WriteLine(Text);
        }
    }
}
