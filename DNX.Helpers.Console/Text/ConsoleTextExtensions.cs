using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class ConsoleTextExtensions.
    /// </summary>
    public static class ConsoleTextExtensions
    {
        /// <summary>
        /// Converts the specified raw text to console text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IConsoleText.</returns>
        public static IConsoleText ToConsoleText(this string text)
        {
            return ConsoleTextHelper.Parse(text);
        }
    }
}
