using CommandLine;
#pragma warning disable 1591

namespace SampleApp
{
    /// <summary>
    /// Arguments class for command line
    /// </summary>
    public class Arguments
    {
        [Value(0, Required = true)]
        public string FileName { get; set; }


        [Option('v', "Verbose", DefaultValue = false, HelpText = "Generate more verbose output")]
        public bool CheckFolderExists { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Arguments"/> class.
        /// </summary>
        public Arguments()
        {
        }
    }
}
