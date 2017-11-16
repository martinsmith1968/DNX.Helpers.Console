using System;
using System.Collections.Generic;

namespace DNX.Helpers.Console.CommandLine.Arguments
{
    public class ValueArgument
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }
    }

    public class OptionArgument
    {
        public string Shortcut { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public int MaxShortcutLength { get; set; }

        public int MaxNameLength { get; set; }

        public string ValueType { get; set; }

        public string Pad
        {
            get
            {
                var padLength = Math.Max(MaxNameLength + MaxShortcutLength - (Name ?? string.Empty).Length - (Shortcut ?? string.Empty).Length, 0);

                return new string(' ', padLength);
            }
        }
    }

    /// <summary>
    /// Class ArgumentsMap.
    /// </summary>
    public class ArgumentsMap
    {
        public IList<ValueArgument> PositionalArguments { get; private set; }

        public IList<OptionArgument> OptionArguments { get; private set; }
    }

    /// <summary>
    /// Class ParserError.
    /// </summary>
    public class ParserError
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
