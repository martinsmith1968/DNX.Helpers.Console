using System;
using System.Linq;
using CommandLine;
using CommandLine.Text;
using DNX.CommandLine.Helpers.Exceptions;

namespace DNX.Helpers.Console.CommandLine
{
    public static class ParserHelper
    {
        public static ParserResult<T> Parse<T>(string[] args)
            where T : new()
        {
            var settings = new ParserSettings();

            return Parse<T>(args, settings);
        }

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

        public static HelpText BuildHelp<T>(ParserResult<T> result)
        {
            var helpText = HelpText.AutoBuild(result);

            return helpText;
        }
    }
}
