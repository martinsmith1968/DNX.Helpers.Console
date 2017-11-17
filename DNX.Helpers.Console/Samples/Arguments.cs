using CommandLine;
using DNX.Helpers.Console.CommandLine;
using DNX.Helpers.Console.Interfaces;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace SampleApp
{
    public enum FileMode { Binary, Text }

    /// <summary>
    /// Arguments class for command line
    /// </summary>
    public class Arguments : IParserSettingsCustomiser, IPostParseValidator
    {
        [Value(0, Required = true, HelpText = "The file to process")]
        public string FileName { get; set; }

        [Value(1, Required = false, HelpText = "The format to read the file in")]
        public string Format { get; set; }

        [Option('c', "CheckExists", Default = false, HelpText = "Check folder exists")]
        public bool CheckFolderExists { get; set; }

        [Option('m', "mode", Default = FileMode.Text, HelpText = "The mode to read the file in")]
        public FileMode Mode { get; set; }

        public void CustomiseSettings(ParserSettings settings)
        {
            // Add custom parser settings here

            //settings.Reset();
            //settings.ShouldThrowOnParseFailure(true);
        }

        public void Validate()
        {
            // Add post-parse validation here
        }
    }

    public class CommandA
    {
        public void Run()
        {
        }
    }

    public class CommandB
    {
        public void Run()
        {
        }
    }

    public class CommandC
    {
        public void Run()
        {
        }
    }

    public class CommandD
    {
        public void Run()
        {
        }
    }
}
