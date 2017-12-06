using CommandLine;
using CommandLine.Text;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Help.Maps;
using DNX.Helpers.Console.CommandLine.Templating;

namespace DNX.Helpers.Console.CommandLine.Help
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
        /// <param name="parserResult">The parserx result.</param>
        /// <param name="verbsIndex">if set to <c>true</c> [verbs index].</param>
        /// <param name="consoleWidth">Width of the console.</param>
        /// <returns>System.String.</returns>
        public static string GetHelpText<T>(this ParserResult<T> parserResult, bool verbsIndex = false, int consoleWidth = 80)
        {
            return HelpText.AutoBuild(parserResult, null, null, verbsIndex, consoleWidth);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>()
        {
            return BuildTemplatedHelpText<T>(null, Templates.StandardTemplate, ParserExtendedSettings.DefaultTemplateEngine);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(ParserResult<T> parserResult)
        {
            return BuildTemplatedHelpText(parserResult, Templates.StandardTemplate);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template">The template.</param>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(ParserResult<T> parserResult, string template)
        {
            return BuildTemplatedHelpText(parserResult, template, ParserExtendedSettings.DefaultTemplateEngine);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template">The template.</param>
        /// <param name="templateEngine">The template engine.</param>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(ParserResult<T> parserResult, string template, ITemplateEngine templateEngine)
        {
            templateEngine.Reset();

            var argumentsMap = ArgumentsMap.Create<T>();

            templateEngine.AddObject("Program", new AssemblyDetails(typeof(T).Assembly));
            templateEngine.AddObject("Arguments", argumentsMap);
            templateEngine.AddObject("ParserResult", parserResult);

            var helpText = templateEngine.Render(template);

            return helpText;
        }
    }
}
