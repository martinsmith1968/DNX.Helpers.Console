using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console.CommandLine.Arguments;
using DNX.Helpers.Console.CommandLine.Templating;
using DNX.Helpers.Console.CommandLine.Templating.Mustachio;
using DNX.Helpers.Reflection;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.CommandLine.Templating
{
    [TestFixture]
    public class TemplateEngineMustachioTests
    {
        private TemplateEngineMustachio _templateEngineMustachio;

        [SetUp]
        public void TestInitialise()
        {
            _templateEngineMustachio = new TemplateEngineMustachio();
        }

        [Test]
        public void RenderTest()
        {
            // Arrange
            var assemblyDetails = new AssemblyDetails(Assembly.GetExecutingAssembly());

            var templateLines = new[]
            {
                "{{Program.Title}} v{{Program.SimplifiedVersion}}{{#Program.Description}} - {{.}}{{/Program.Description}}",
                "{{Program.Copyright}}",
                "{{#Parser.Failed}}",
                "",
                "Errors:",
                "{{#each Parser.Errors}}",
                "  {{Message}}",
                "{{/each}}",
                "{{/Parser.Failed}}",
                "",
                "Usage:",
                "{{Program.FileName}}",
            };

            dynamic parser = new ExpandoObject();
            parser.Failed = true;
            parser.Errors = new List<IDictionary<string, object>>()
            {
                (new ParserError() { Message = "Unknown option : -k"}).ToDictionary()
            };

            _templateEngineMustachio.AddObject("Parser", parser);

            // Act
            var result = _templateEngineMustachio.Render(templateLines);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.Length.ShouldBeGreaterThan(0);

            var lines = result.Split(Environment.NewLine.ToCharArray().First())
                .Select(l => l.RemoveStartsWith(string.Join("", Environment.NewLine.Skip(1))))
                .ToList();
            lines.Count.ShouldBe(templateLines.Length - 1);

            lines.Skip(0).First().ShouldBe(string.Format("{0} v{1}", assemblyDetails.Title, assemblyDetails.SimplifiedVersion));
            lines.Skip(1).First().ShouldBe(string.Format("{0}", assemblyDetails.Copyright));
            lines.Skip(2).First().ShouldBe("");
            lines.Skip(3).First().ShouldBe("Usage:");
            lines.Skip(4).First().ShouldBe(string.Format("{0}", assemblyDetails.FileName));
        }
    }
}