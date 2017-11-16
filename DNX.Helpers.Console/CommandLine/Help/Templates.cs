using System;

namespace DNX.Helpers.Console.CommandLine.Help
{
    /// <summary>
    /// Class Templates.
    /// </summary>
    public class Templates
    {
        /// <summary>
        /// The standard template lines
        /// </summary>
        public static readonly string[] StandardTemplateLines = new[]
        {
            "{{Program.Title}} v{{Program.SimplifiedVersion}}{% if Program.Description %} - {{Program.Description}}{% endif %}",
            "{{Program.Copyright}}",
            "{% if Parser.Failed -%}",
            "",
            "Errors:",
            "{% for error in Parser.Errors -%}",
            "  {{error.Message}}",
            "{% endfor -%}",
            "{% endif -%}",
            "",
            "Usage:",
            "{{Program.FileName}}{% for a in Parser.Positional %} [{{a.Name}}]{% endfor %}{% if Parser.Options %} { [options] }{% endif %}",
            "{% if Parser.Options %}",
            "Options:",
            "{% for o in Parser.Options -%}",
            "  -{{ o.Shortcut }}{% if o.Name%}, --{{ o.Name }}{% else %}    {% endif %}{{ o.Pad }}  {% if o.ValueType %}({{o.ValueType}}){% endif %} {{o.Description}}",
            "{% endfor -%}",
            "{% endif %}",
        };

        /// <summary>
        /// Gets the standard template.
        /// </summary>
        /// <value>The boilerplate template.</value>
        public static string StandardTemplate
        {
            get { return string.Join(Environment.NewLine, StandardTemplateLines); }
        }
    }
}
