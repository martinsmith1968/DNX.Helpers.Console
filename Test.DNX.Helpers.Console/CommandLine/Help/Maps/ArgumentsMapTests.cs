using System.Linq;
using CommandLine;
using DNX.Helpers.Console.CommandLine.Help.Maps;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.CommandLine.Help.Maps
{
    internal enum VerbosityLevel
    {
        Quiet,
        Info,
        Diagnostic
    }

    internal class MyArguments1
    {
        [Value(1, Required = true, HelpText = "The file to process")]
        public string FileName { get; set; }

        [Value(2, Required = false, Default = "xml", HelpText = "The format of the file")]
        public string Format { get; set; }

        [Option('l', "maxlevel", Default = 3, HelpText = "The maximum number of levels to process", Required = false)]
        public int MaxLevel { get; set; }

        [Option('v', "verbosity", Default = VerbosityLevel.Info, HelpText = "The level for messaging during execution", Required = false)]
        public VerbosityLevel Verbosity { get; set; }
    }

    [TestFixture]
    public class ArgumentsMapTests
    {
        [Test]
        public void ArgumentsMap_can_detect_the_correct_number_of_arguments()
        {
            // Arrange

            // Act
            var result = ArgumentsMap.Create<MyArguments1>();

            // Assert
            result.ShouldNotBeNull();
            result.Positional.Count.ShouldBe(2);
            result.Positional.Any(p => p.ContainsKey(@"Name") && p[@"Name"].Equals("FileName")).ShouldBeTrue();
            result.Positional.Any(p => p.ContainsKey(@"Name") && p[@"Name"].Equals("Format")).ShouldBeTrue();

            result.Options.Count.ShouldBe(3);
            result.Options.Any(p => p.ContainsKey(@"Name") && p[@"Name"].Equals("maxlevel")).ShouldBeTrue();
            result.Options.Any(p => p.ContainsKey(@"Name") && p[@"Name"].Equals("verbosity")).ShouldBeTrue();
            result.Options.Any(p => p.ContainsKey(@"Name") && p[@"Name"].Equals("help")).ShouldBeTrue();
        }
    }
}
