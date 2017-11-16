using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Reflection;
using DotLiquid;

namespace DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    /// <summary>
    /// Class TemplateEngineMustachio.
    /// </summary>
    public class TemplateEngineDotLiquid
    {
        private readonly IDictionary<string, object> _substitutables = new Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateEngineDotLiquid"/> class.
        /// </summary>
        public TemplateEngineDotLiquid()
        {
            Template.RegisterFilter(typeof(OptionPadder));

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
        /// <param name="instance">The instance.</param>?
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
            var renderer = Template.Parse(template);

            var parms = Hash.FromDictionary(_substitutables);

            var output = renderer.Render(parms);

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
