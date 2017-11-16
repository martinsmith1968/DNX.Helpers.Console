using DotLiquid;

namespace DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    /// <inheritdoc />
    /// <summary>
    /// Class DotLiquidTemplateEngine.
    /// </summary>
    /// <seealso cref="T:DNX.Helpers.Console.CommandLine.Help.Templating.BaseTemplateEngine" />
    public class DotLiquidTemplateEngine : BaseTemplateEngine
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.CommandLine.Templating.DotLiquid.DotLiquidTemplateEngine" /> class.
        /// </summary>
        public DotLiquidTemplateEngine()
        {
            Template.RegisterFilter(typeof(OptionPadder));
        }

        /// <inheritdoc />
        /// <summary>
        /// Renders the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>System.String.</returns>
        public override string Render(string template)
        {
            var renderer = Template.Parse(template);

            var substitutionHash = Hash.FromDictionary(Substitutables);

            var output = renderer.Render(substitutionHash);

            return output;
        }
    }
}
