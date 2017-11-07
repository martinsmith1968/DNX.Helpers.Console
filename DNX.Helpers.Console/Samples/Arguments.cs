using CommandLine;
#pragma warning disable 1591

namespace SampleApp
{
    /// <summary>
    /// Arguments class for command line
    /// </summary>
    public class Arguments
    {
        [Value(0, Required = true, HelpText = "The file to process")]
        public string FileName { get; set; }


        [Option('c', "CheckExists", Default = false, HelpText = "Check folder exists")]
        public bool CheckFolderExists { get; set; }
    }
}
