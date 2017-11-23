using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Reflection;

#pragma warning disable 1591

namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    /// <summary>
    /// Class ArgumentsMap.
    /// </summary>
    public class ArgumentsMap
    {
        protected Type Type { get; private set; }

        protected IList<PositionalArgumentMap> PositionalArguments = new List<PositionalArgumentMap>();
        protected IList<OptionArgumentMap> OptionArguments = new List<OptionArgumentMap>();

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
                new PositionalArgumentMap() { Name = "Filename", Position = 1, Required = true }
            );
            PositionalArguments.Add(
                new PositionalArgumentMap() { Name = "Format", Position = 2, Required = false }
            );

            OptionArguments.Add(
                new OptionArgumentMap() { Shortcut = "m", Name = "mode", Description = "The mode to read the file in", Required = false, ValueType = "Text | Binary" }
            );
            OptionArguments.Add(
                new OptionArgumentMap() { Shortcut = "v", Name = "verbose", Description = "Verbosely report progress", Required = false }
            );
            OptionArguments.Add(
                new OptionArgumentMap() { Shortcut = "x", Description = "Turn on debug mode", Required = false }
            );
            OptionArguments.Add(
                new OptionArgumentMap() { Shortcut = "?", Name = "help", Description = "Show the help page", Required = false }
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
}
