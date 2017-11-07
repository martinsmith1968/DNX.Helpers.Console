using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Strings;

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
                settings.MaximumDisplayWidth       = System.Console.WindowWidth;
            }
        };

        /// <summary>
        /// Parses the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> Parse<T>(this Parser parser, string[] args)
            where T : new()
        {
            var expandedArgs = ExpandArgs(args);

            var result = parser.ParseArguments<T>(expandedArgs);
            if (result.Ok())
            {
                ValidateInstance(result);
            }

            return result;
        }

        /// <summary>
        /// Custom validation on the arguments options instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        private static void ValidateInstance<T>(ParserResult<T> result)
            where T : new()
        {
            var validator = result.Result().Value as ISettingsValidator;
            if (validator != null)
            {
                validator.Validate();
            }
        }

        /// <summary>
        /// Expands the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> ExpandArgs(IEnumerable<string> args)
        {
            var expandedArgs = new List<string>();

            foreach (var arg in args)
            {
                if (arg.StartsWith("@"))
                {
                    var fileInfo = new FileInfo(arg.RemoveStartsWith("@"));
                    if (fileInfo.Exists)
                    {
                        expandedArgs.AddRange(File.ReadAllLines(fileInfo.FullName));
                    }
                }
                else
                {
                    expandedArgs.Add(arg);
                }
            }

            return expandedArgs;
        }
    }
}
