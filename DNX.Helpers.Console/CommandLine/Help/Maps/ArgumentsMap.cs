using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CommandLine;
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

        protected IList<PositionalArgumentInfo> PositionalArguments = new List<PositionalArgumentInfo>();
        protected IList<OptionArgumentInfo> OptionArguments = new List<OptionArgumentInfo>();

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

            GetArgumentProperties(type)
                .Where(t => ArgumentInfo.IsPositionalArgument(t))
                .ToList()
                .ForEach(p => PositionalArguments.Add(ArgumentInfo.GetPositionalArgumentInfo(p)));

            GetArgumentProperties(type)
                .Where(t => ArgumentInfo.IsOptionArgument(t))
                .ToList()
                .ForEach(p => OptionArguments.Add(ArgumentInfo.GetOptionArgumentInfo(p)));
            OptionArguments.Add(GenerateHelpOption());

            OptionArguments
                .ToList()
                .ForEach(opt =>
                {
                    opt.MaxShortcutLength = OptionArguments.Max(o => (o.Shortcut ?? string.Empty).Length);
                    opt.MaxNameLength     = OptionArguments.Max(o => (o.Name ?? string.Empty).Length);
                });
        }

        private static OptionArgumentInfo GenerateHelpOption()
        {
            var helpOption = new OptionAttribute('?', "help")
            {
                HelpText = "Display this Help page",
                Required = false,
                SetName  = "BuiltIn:99"
            };

            return OptionArgumentInfo.Create(null, helpOption);
        }

        private IList<PropertyInfo> GetArgumentProperties(Type type)
        {
            return type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty)
                .ToList();
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
