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
        /// Initializes a new instance of the <see cref="ConsoleText" /> class.
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

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IList&lt;IConsoleText&gt;.</returns>
        public IList<IConsoleText> Parse(string text)
        {
            var list = new List<IConsoleText>();

            // var sampleText = "The error should [[Yellow]]appear in [[Red]]Red[[/Red]][[/Yellow]].";

            while (!string.IsNullOrEmpty(text))
            {
                var item = ConsoleText.Parse(ref text);

                if (item != null)
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}
