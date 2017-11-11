using System;
using CommandLine;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserSettingsCustomiserHelper.
    /// </summary>
    public class ParserSettingsHelper
    {
        /// <summary>
        /// The default parser customiser
        /// </summary>
        public static Action<ParserSettings> DefaultParserCustomiser = (settings) =>
        {
            settings.IgnoreUnknownArguments    = false;
            settings.CaseInsensitiveEnumValues = true;
            settings.HelpWriter                = System.Console.Error;

            if (!System.Console.IsOutputRedirected)
            {
                settings.MaximumDisplayWidth = System.Console.WindowWidth;
            }
        };

        /// <summary>
        /// Determines whether this instance can customise the settings for the specified parser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns><c>true</c> if this instance can customise the settings for the specified parser; otherwise, <c>false</c>.</returns>
        public static bool CanCustomiseSettings<T>()
            where T : new()
        {
            var customiser = new T() as IParserSettingsCustomiser;

            return customiser != null;
        }

        /// <summary>
        /// Gets the settings customiser.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Action&lt;ParserSettings&gt;.</returns>
        public static Action<ParserSettings> GetSettingsCustomiser<T>()
            where T : new()
        {
            var customiser = new T() as IParserSettingsCustomiser;

            return customiser == null
                ? ParserSettingsChain.Create()
                : ParserSettingsChain.Create(customiser.CustomiseSettings);
        }
    }
}
