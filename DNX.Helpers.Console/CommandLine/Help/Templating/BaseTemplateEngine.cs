using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.Console.CommandLine.Help.Templating
{
    /// <summary>
    /// Class DotLiquidTemplateEngine.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.CommandLine.Help.Templating.ITemplateEngine" />
    public abstract class BaseTemplateEngine : ITemplateEngine
    {
        /// <summary>
        /// The substitutables
        /// </summary>
        protected readonly IDictionary<string, object> Substitutables;

        /// <summary>
        /// Initializes a new instance of the <see cref="DotLiquidTemplateEngine"/> class.
        /// </summary>
        protected BaseTemplateEngine()
        {
            Substitutables = new Dictionary<string, object>();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            Substitutables.Clear();
        }

        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="instance">The instance.</param>
        public void AddObject(string name, object instance)
        {
            var dict = instance as IDictionary<string, object>
                       ?? instance.ToDictionary();

            Substitutables[name] = dict;
        }

        /// <summary>
        /// Renders the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public abstract string Render(string template);

        /// <summary>
        /// Renders the specified template lines.
        /// </summary>
        /// <param name="templateLines">The template lines.</param>
        /// <returns>System.String.</returns>
        public IList<string> Render(IList<string> templateLines)
        {
            var output = templateLines
                .Select(tl => Render(tl))
                .ToList();

            return output;
        }
    }
}
