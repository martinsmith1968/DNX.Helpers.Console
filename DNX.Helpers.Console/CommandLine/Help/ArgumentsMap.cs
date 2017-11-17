using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Reflection;
#pragma warning disable 1591

namespace DNX.Helpers.Console.CommandLine.Help
{
    public class ValueArgument
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public bool Optional { get { return !Required; } }
    }

    public class OptionArgument
    {
        public string Shortcut { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public string DefaultValue { get; set; }

        public int MaxShortcutLength { get; set; }

        public int MaxNameLength { get; set; }

        public string ValueType { get; set; }

        public string ValueList { get; set; }

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
        protected Type Type { get; private set; }

        protected IList<ValueArgument> PositionalArguments = new List<ValueArgument>();
        protected IList<OptionArgument> OptionArguments = new List<OptionArgument>();

        public IList<IDictionary<string, object>> Positional
        {
            get
            {
                return PositionalArguments
                    .Select(pa => pa.ToDictionary())
                    .ToList();
            }
        }

        public IList<IDictionary<string, object>> Options
        {
            get
            {
                return OptionArguments
                    .Select(oa => oa.ToDictionary())
                    .ToList();
            }
        }

        public ArgumentsMap(Type type)
        {
            Type = type;

            PositionalArguments.Add(
                new ValueArgument() { Name = "Filename", Position = 1, Required = true }
            );
            PositionalArguments.Add(
                new ValueArgument() { Name = "Format", Position = 2, Required = false }
            );

            OptionArguments.Add(
                new OptionArgument() { Shortcut = "m", Name = "mode", Description = "The mode to read the file in", Required = false, ValueType = "Text | Binary" }
            );
            OptionArguments.Add(
                new OptionArgument() { Shortcut = "v", Name = "verbose", Description = "Verbosely report progress", Required = false }
            );
            OptionArguments.Add(
                new OptionArgument() { Shortcut = "x", Description = "Turn on debug mode", Required = false }
            );
            OptionArguments.Add(
                new OptionArgument() { Shortcut = "?", Name = "help", Description = "Show the help page", Required = false }
            );

            OptionArguments
                .ToList()
                .ForEach(opt =>
                {
                    opt.MaxShortcutLength = OptionArguments.Max(o => (o.Shortcut ?? string.Empty).Length);
                    opt.MaxNameLength     = OptionArguments.Max(o => (o.Name ?? string.Empty).Length);
                });
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.Object.</returns>
        public static ArgumentsMap Create<T>()
        {
            var argumentsMap = new ArgumentsMap(typeof(T));

            return argumentsMap;
        }
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
