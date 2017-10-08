using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using DNX.CommandLine.Helpers.Exceptions;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserHelper.
    /// </summary>
    public static class ParserHelper
    {
        /// <summary>
        /// Parses the specified arguments using default Parser settings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> Parse<T>(string[] args)
            where T : new()
        {
            var settings = new ParserSettings();

            return Parse<T>(args, settings);
        }

        /// <summary>
        /// Parses the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        /// <exception cref="ParserResultException{T}"></exception>
        public static ParserResult<T> Parse<T>(string[] args, ParserSettings settings)
            where T : new()
        {
            using (var parser = new Parser(x => ApplySettings(x, settings)))
            {
                var result = parser.ParseArguments<T>(args);

                if (result.Errors.Any())
                {
                    throw new ParserResultException<T>(result, string.Join(Environment.NewLine, result.Errors));
                }

                return result;
            }
        }

        private static void ApplySettings(ParserSettings target, ParserSettings source)
        {
            target.CaseSensitive          = source.CaseSensitive;
            target.ParsingCulture         = source.ParsingCulture;
            target.HelpWriter             = source.HelpWriter;
            target.IgnoreUnknownArguments = source.IgnoreUnknownArguments;
            target.EnableDashDash         = source.EnableDashDash;
        }

        /// <summary>
        /// Builds the help text using default automatic settings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>HelpText.</returns>
        public static HelpText BuildHelp<T>(ParserResult<T> result)
        {
            var helpText = HelpText.AutoBuild(result);

            return helpText;
        }
    }
}
