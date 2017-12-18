using System.Collections.Generic;
using System.IO;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Text.Items
{
    /// <summary>
    /// Class ConsoleTextCollection.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleTextItem" />
    public class TextItemCollection : IConsoleTextItem
    {
        /// <summary>
        /// Gets the parts.
        /// </summary>
        /// <value>The parts.</value>
        public IList<IConsoleTextItem> Parts { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleTextHelper" /> class.
        /// </summary>
        public TextItemCollection()
        {
            Parts = new List<IConsoleTextItem>();
        }

        /// <summary>
        /// Writes the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void Write(TextWriter textWriter)
        {
            foreach (var part in Parts)
            {
                part.Write(textWriter);
            }
        }

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        public void WriteLine(TextWriter textWriter)
        {
            Write(textWriter);
            textWriter.WriteLine();
        }
    }
}
