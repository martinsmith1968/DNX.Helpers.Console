using System.IO;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Strings;

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

        /// <summary>
        /// Determines whether this instance can parse the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if this instance can parse the specified text; otherwise, <c>false</c>.</returns>
        public static bool CanParse(string text)
        {
            return !string.IsNullOrEmpty(text)
                   && (!text.Contains("[[") || !string.IsNullOrEmpty(text.Before("[[")));
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>PlainText.</returns>
        public static PlainText Parse(ref string text)
        {
            if (!CanParse(text))
            {
                return null;
            }

            var plainText = text.Before("[[");

            var instance = new PlainText(plainText);

            text = text.RemoveStartsWith(plainText);

            return instance;
        }
    }
}
