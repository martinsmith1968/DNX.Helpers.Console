using System.Reflection;
using CommandLine;
using CommandLine.Text;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Help.Templating;

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
        /// <param name="parserResult">The parser result.</param>
        /// <param name="verbsIndex">if set to <c>true</c> [verbs index].</param>
        /// <param name="consoleWidth">Width of the console.</param>
        /// <returns>System.String.</returns>
        public static string GetHelpText<T>(ParserResult<T> parserResult, bool verbsIndex = false, int consoleWidth = 80)
        {
            return HelpText.AutoBuild(parserResult, null, null, verbsIndex, consoleWidth);
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
            return BuildTemplatedHelpText(template, parserResult, ParserExtendedSettings.TemplateEngine);
        }

        /// <summary>
        /// Builds the templated help text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="template">The template.</param>
        /// <param name="parserResult">The parser result.</param>
        /// <param name="templateEngine">The template engine.</param>
        /// <returns>System.String.</returns>
        public static string BuildTemplatedHelpText<T>(string template, ParserResult<T> parserResult, ITemplateEngine templateEngine)
        {
            templateEngine.Reset();

            templateEngine.AddObject("Program", new AssemblyDetails(Assembly.GetEntryAssembly()));

            var argumentsMap = ArgumentsMap.Create<T>();
            templateEngine.AddObject("Arguments", argumentsMap);

            templateEngine.AddObject("Result", parserResult);

            var helpText = templateEngine.Render(template);

            return helpText;
        }
    }
}
