using System.Collections.Generic;

namespace DNX.Helpers.Console.CommandLine.Templating
{
    /// <summary>
    /// Interface ITemplateEngine
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();

        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="instance">The instance.</param>
        void AddObject(string name, object instance);

        /// <summary>
        /// Renders the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <returns>System.String.</returns>
        string Render(string template);

        /// <summary>
        /// Renders the specified template lines.
        /// </summary>
        /// <param name="templateLines">The template lines.</param>
        /// <returns>System.String.</returns>
        IList<string> Render(IList<string> templateLines);
    }
}
