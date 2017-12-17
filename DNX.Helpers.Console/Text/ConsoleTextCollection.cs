using System.Collections.Generic;
using System.IO;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class ConsoleTextCollection.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleText" />
    public class ConsoleTextCollection : IConsoleText
    {
        /// <summary>
        /// Gets the parts.
        /// </summary>
        /// <value>The parts.</value>
        public IList<IConsoleText> Parts { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleTextHelper" /> class.
        /// </summary>
        public ConsoleTextCollection()
        {
            Parts = new List<IConsoleText>();
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
