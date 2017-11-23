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
            return BuildTemplatedHelpText<T>(Templates.StandardTemplate, ParserExtendedSettings.TemplateEngine, null);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(ParserResult<T> parserResult)
        {
            return BuildTemplatedHelpText(Templates.StandardTemplate, parserResult);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template">The template.</param>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(string template, ParserResult<T> parserResult)
        {
            return BuildTemplatedHelpText(template, ParserExtendedSettings.TemplateEngine, parserResult);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template">The template.</param>
        /// <param name="templateEngine">The template engine.</param>
        /// <param name="parserResult">The parser result.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(string template, ITemplateEngine templateEngine, ParserResult<T> parserResult)
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
