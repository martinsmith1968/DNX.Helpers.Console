using System.Collections.Generic;
using System.IO;
using DNX.Helpers.Strings;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ArgumentExtensions.
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Expands the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> Expand(this IEnumerable<string> args)
        {
            var expandedArgs = new List<string>();

            foreach (var arg in args)
            {
                if (arg.StartsWith("@"))
                {
                    var fileInfo = new FileInfo(arg.RemoveStartsWith("@"));
                    if (fileInfo.Exists)
                    {
                        expandedArgs.AddRange(File.ReadAllLines(fileInfo.FullName));
                    }
                }
                else
                {
                    expandedArgs.Add(arg);
                }
            }

            return expandedArgs;
        }
    }
}
