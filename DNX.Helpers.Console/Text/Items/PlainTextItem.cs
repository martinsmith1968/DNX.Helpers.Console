using System.IO;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Text.Items
{
    /// <summary>
    /// Class RawText.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleTextItem" />
    public class PlainTextItem : IConsoleTextItem
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlainTextItem"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public PlainTextItem(string text)
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
            return !string.IsNullOrEmpty(ConsoleTextHelper.GetCurrentPlainText(text));
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>PlainTextItem.</returns>
        public static PlainTextItem Parse(ref string text)
        {
            if (!CanParse(text))
            {
                return null;
            }

            var plainText = ConsoleTextHelper.GetCurrentPlainText(text);

            var instance = new PlainTextItem(plainText);

            text = text.RemovePlainText(plainText);

            return instance;
        }
    }
}
