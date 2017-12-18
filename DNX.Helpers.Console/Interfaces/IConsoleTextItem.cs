using System.IO;

namespace DNX.Helpers.Console.Interfaces
{
    /// <summary>
    /// Interface ITextPiece
    /// </summary>
    public interface IConsoleTextItem
    {
        /// <summary>
        /// Writes the specified text writer.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        void Write(TextWriter textWriter);

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        void WriteLine(TextWriter textWriter);
    }
}
