using System;
using System.Collections.Generic;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.Console.CommandLine.Templating.Mustachio
{
    /// <summary>
    /// Class TemplateEngineMustachio.
    /// </summary>
    public class TemplateEngineMustachio
    {
        private readonly IDictionary<string, object> _substitutables = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateEngineMustachio"/> class.
        /// </summary>
        public TemplateEngineMustachio()
        {
            AddObject("Program", new AssemblyDetails(Assembly.GetCallingAssembly()));
        }

        /// <summary>
        /// Clears the objects.
        /// </summary>
        public void ClearObjects()
        {
            _substitutables.Clear();
        }

        /// <summary>
        /// Adds the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">The name.</param>
        /// <param name="instance">The instance.</param>
        public void AddObject<T>(string name, T instance)
        {
            var dict = instance as IDictionary<string, object>
                       ?? instance.ToDictionary();

            if (string.IsNullOrEmpty(name) || dict == null)
            {
                return;
            }

            _substitutables[name] = dict;
        }

        /// <summary>
        /// Renders the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="substitutables">The substitutables.</param>
        /// <returns>System.String.</returns>
        public string Render(string template, IDictionary<string, object> substitutables = null)
        {
            var renderer = global::Mustachio.Parser.Parse(template, true);

            var output = renderer(substitutables ?? _substitutables);

            return output;
        }

        /// <summary>
        /// Renders the specified template lines.
        /// </summary>
        /// <param name="templateLines">The template lines.</param>
        /// <param name="substitutables">The substitutables.</param>
        /// <returns>System.String.</returns>
        public string Render(IList<string> templateLines, IDictionary<string, object> substitutables = null)
        {
            var template = string.Join(Environment.NewLine, templateLines);

            return Render(template, substitutables);
        }
    }
}
