namespace DNX.Helpers.Console.CommandLine.Help.Templating
{
    /// <summary>
    /// Class TemplateEngineFactory.
    /// </summary>
    public static class TemplateEngineFactory
    {
        /// <summary>
        /// Gets or sets the template engine.
        /// </summary>
        /// <value>The template engine.</value>
        public static ITemplateEngine TemplateEngine
        {
            get { return ParserExtendedSettings.TemplateEngine; }
        }
    }
}
