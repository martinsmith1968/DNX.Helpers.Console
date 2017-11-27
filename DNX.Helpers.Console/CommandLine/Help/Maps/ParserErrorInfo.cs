using System;

namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    /// <summary>
    /// Class ParserError.
    /// </summary>
    public class ParserErrorInfo
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get { return Guid.NewGuid().ToString(); } }
    }
}
