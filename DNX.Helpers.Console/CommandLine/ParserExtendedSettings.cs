using DNX.Helpers.Console.CommandLine.Help.Templating;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserExtendedSettings.
    /// </summary>
    public class ParserExtendedSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the Parser should throw an Exception if parsing fails
        /// </summary>
        /// <value><c>true</c> to throw on parse failure; otherwise, <c>false</c>.</value>
        public static bool ThrowOnParseFailure { get; set; }

        /// <summary>
        /// Gets or sets the type of the defaul template engine.
        /// </summary>
        /// <value>The type of the defaul template engine.</value>
        public static ITemplateEngine TemplateEngine { get; set; }

        static ParserExtendedSettings()
        {
            Reset();
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        public static void Reset()
        {
            ThrowOnParseFailure = false;
            TemplateEngine      = new DotLiquidTemplateEngine();
        }
    }
}
