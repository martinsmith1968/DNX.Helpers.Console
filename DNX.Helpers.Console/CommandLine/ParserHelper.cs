using System;
using CommandLine;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserHelper.
    /// </summary>
    public static class ParserHelper
    {
        /// <summary>
        /// Gets the default parser.
        /// </summary>
        /// <value>The default parser.</value>
        public static Parser DefaultParser
        {
            get
            {
                return new Parser(DefaultParserConfiguration);
            }
        }

        /// <summary>
        /// The default parser configuration
        /// </summary>
        public static Action<ParserSettings> DefaultParserConfiguration = settings =>
        {
            settings.IgnoreUnknownArguments    = false;
            settings.CaseInsensitiveEnumValues = true;

            if (!System.Console.IsOutputRedirected)
            {
                settings.MaximumDisplayWidth = System.Console.WindowWidth;
            }
        };

        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Parser.</returns>
        public static Parser GetParser<T>()
            where T : new()
        {
            return GetParser<T>(DefaultParser);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Parser.</returns>
        public static Parser GetParser<T>(Parser defaultParser)
            where T : new()
        {
            var configurator = new T() as IParserSettingsConfigurator;

            return (configurator != null)
                ? new Parser(configurator.SettingsConfigurator)
                : defaultParser;
        }


        /// <summary>
        /// Gets the parser and parse.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> GetParserAndParse<T>(string[] args)
            where T : new()
        {
            return GetParserAndParse<T>(args, DefaultParser);
        }

        /// <summary>
        /// Gets the parser and parse.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <param name="defaultParser">The default parser.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> GetParserAndParse<T>(string[] args, Parser defaultParser)
            where T : new()
        {
            var parser = GetParser<T>(defaultParser);

            return parser.ParseAndValidate<T>(args);
        }
    }
}
