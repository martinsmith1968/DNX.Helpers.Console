using CommandLine;
using CommandLine.Text;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class HelpBuilder.
    /// </summary>
    public static class HelpBuilder
    {
        /// <summary>
        /// Gets the help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parserResult">The parser result.</param>
        /// <param name="verbsIndex">if set to <c>true</c> [verbs index].</param>
        /// <param name="consoleWidth">Width of the console.</param>
        /// <returns>System.String.</returns>
        public static string GetHelpText<T>(ParserResult<T> parserResult, bool verbsIndex = false, int consoleWidth = 80)
        {
            return HelpText.AutoBuild(parserResult, null, null, verbsIndex, consoleWidth);
        }
    }
}
