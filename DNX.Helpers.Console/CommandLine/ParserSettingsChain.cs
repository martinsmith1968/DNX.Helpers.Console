using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserSettingsChain.
    /// </summary>
    public static class ParserSettingsChain
    {
        /// <summary>
        /// Creates the specified chain.
        /// </summary>
        /// <param name="chain">The chain.</param>
        /// <returns>Action&lt;ParserSettings&gt;.</returns>
        public static Action<ParserSettings> Create(params Action<ParserSettings>[] chain)
        {
            return Create(chain.ToList());
        }

        /// <summary>
        /// Creates the specified chain.
        /// </summary>
        /// <param name="chain">The chain.</param>
        /// <returns>Action&lt;ParserSettings&gt;.</returns>
        public static Action<ParserSettings> Create(IList<Action<ParserSettings>> chain)
        {
            return settings =>
            {
                chain
                    .ToList()
                    .ForEach(ch =>
                    {
                        if (ch != null)
                        {
                            ch(settings);
                        }
                    });
            };
        }
    }
}
