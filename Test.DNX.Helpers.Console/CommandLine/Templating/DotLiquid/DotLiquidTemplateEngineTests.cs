using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Help;
using DNX.Helpers.Console.CommandLine.Templating.DotLiquid;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    [TestFixture]
    public class DotLiquidTemplateEngineTests
    {
        private DotLiquidTemplateEngine _templateEngine;

        private static readonly string[] BoilerplateTemplateLines = new[]
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

        [SetUp]
        public void TestInitialise()
        {
            _templateEngine = new DotLiquidTemplateEngine();
        }

        [Test]
        public void RenderTest()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());

            dynamic parser = new ExpandoObject();
            parser.Failed = true;
            parser.ShortcutPrefix = "-";
            parser.NamePrefix = "--";
            parser.Errors = new List<IDictionary<string, object>>()
            {
                (new ParserError() { Message = "Unknown option : -k"}).ToDictionary()
            };
            parser.Positional = new List<IDictionary<string, object>>()
            {
                (new ValueArgument() { Name = "Filename", Required = true }).ToDictionary(),
                (new ValueArgument() { Name = "Format", Required = false }).ToDictionary(),
            };
            var options = new List<OptionArgument>()
            {
                new OptionArgument() { Shortcut = "m", Name = "mode", Description = "The mode to read the file in", Required = false, ValueType = "Text | Binary"  },
                new OptionArgument() { Shortcut = "v", Name = "verbose", Description = "Verbosely report progress", Required = false, ValueType = "bool" },
                new OptionArgument() { Shortcut = "x", Description = "Turn on debug mode", Required = false, ValueType = "bool" },
                new OptionArgument() { Shortcut = "?", Name = "help", Description = "Show the help page", Required = false }
            };

            options
                .ForEach(opt =>
                {
                    opt.MaxShortcutLength = options.Max(o => (o.Shortcut ?? string.Empty).Length);
                    opt.MaxNameLength = options.Max(o => (o.Name ?? string.Empty).Length);
                });

            parser.Options = options
                .Select(o => o.ToDictionary());

            _templateEngine.AddObject("Parser", parser);

            // Act
            var resultLines = _templateEngine.Render(BoilerplateTemplateLines);
            var result = string.Join(Environment.NewLine, resultLines);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.Length.ShouldBeGreaterThan(0);

            var lines = result.Split(Environment.NewLine.ToCharArray().First())
                .Select(l => l.RemoveStartsWith(string.Join("", Environment.NewLine.Skip(1))))
                .ToList();
            lines.Count.ShouldBe(BoilerplateTemplateLines.Length - 1);

            lines.Skip(0).First().ShouldBe(string.Format("{0} v{1} - {2}", assemblyDetails.Title, assemblyDetails.SimplifiedVersion, assemblyDetails.Description));
            lines.Skip(1).First().ShouldBe(string.Format("{0}", assemblyDetails.Copyright));
            lines.Skip(2).First().ShouldBe("");
            lines.Skip(3).First().ShouldBe("Usage:");
            lines.Skip(4).First().ShouldBe(string.Format("{0}", assemblyDetails.FileName));
        }
    }
}
