using System;
#pragma warning disable 1591

namespace DNX.Helpers.Console.CommandLine.Help
{
    /// <summary>
    /// Class Templates.
    /// </summary>
    public static class Templates
    {
        public const string ProgramHeader = "{{Program.Title}} v{{Program.SimplifiedVersion}}{% if Program.Description %} - {{Program.Description}}{% endif %}";

        public const string ProgramUsage = "{{Program.FileName}}{% for a in Arguments.Positional %} {% if a.Optional %}{ {% endif %}[{{a.Name}}]{% if a.Optional %} }{% endif %}{% endfor %}{% if Arguments.Options %} { [options] }{% endif %}";

        public const string ProgramOption = "-{{ o.Shortcut }}{% if o.Name%}, --{{ o.Name }}{% else %}    {% endif %}{{ o.Pad }}  {{o.Description}}{% if o.ValueType %} ({{o.ValueType}}){% endif %}";

        /// <summary>
        /// The standard template lines
        /// </summary>
        public static readonly string[] StandardTemplateLines = new[]
        {
            ProgramHeader,
            "{{Program.Copyright}}",
            "{% if ParserResult.Failed -%}",
            "",
            "Errors:",
            "{% for e in ParserResult.Errors -%}",
            "{{e.Message}}",
            "{% endfor -%}",
            "{% endif -%}",
            "",
            "Usage:",
            ProgramUsage,
            "{% if Arguments.Options -%}",
            "",
            "Options:",
            "{% for o in Arguments.Options -%}",
            ProgramOption,
            "{% endfor -%}",
            "{% endif -%}",
            "",
            ""
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
