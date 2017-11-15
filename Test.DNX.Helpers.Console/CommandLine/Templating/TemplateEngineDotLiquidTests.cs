﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Arguments;
using DNX.Helpers.Console.CommandLine.Templating.DotLiquid;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.CommandLine.Templating
{
    [TestFixture]
    public class TemplateEngineDotLiquidTests
    {
        private TemplateEngineDotLiquid _templateEngineDotLiquid;

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
            "  -{{ o.Shortcut | padoptionby2 }}{{o.Name}}. {{o.Description}}",
            "{% endfor %}",
            "{% endif %}",
        };

        [SetUp]
        public void TestInitialise()
        {
            _templateEngineDotLiquid = new TemplateEngineDotLiquid();
        }

        [Test]
        public void RenderTest()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());

            dynamic parser = new ExpandoObject();
            parser.Failed = true;
            parser.Errors = new List<IDictionary<string, object>>()
            {
                (new ParserError() { Message = "Unknown option : -k"}).ToDictionary()
            };
            parser.Positional = new List<IDictionary<string, object>>()
            {
                (new ValueArgument() { Name = "Filename", Required = true }).ToDictionary(),
                (new ValueArgument() { Name = "Format", Required = false }).ToDictionary(),
            };
            parser.Options = new List<IDictionary<string, object>>()
            {
                (new OptionArgument() { Shortcut = "m", Name = "mode", Description = "The mode to read the file in", Required = false }).ToDictionary(),
                (new OptionArgument() { Shortcut = "v", Name = "verbose", Description = "Verbosely report progress", Required = false }).ToDictionary(),
                (new OptionArgument() { Shortcut = "help", Name = "help", Description = "Show the help page", Required = false }).ToDictionary(),
            };

            _templateEngineDotLiquid.AddObject("Parser", parser);

            // Act
            var result = _templateEngineDotLiquid.Render(BoilerplateTemplateLines);

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
