using System.Reflection;
using CommandLine;

#pragma warning disable 1591
namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    public class OptionArgumentInfo : IArgumentInfo
    {
        public string Shortcut { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public bool Optional { get { return !Required; } }

        public string DefaultValue { get; set; }

        public int MaxShortcutLength { get; set; }

        public int MaxNameLength { get; set; }

        public string ValueType { get; set; }

        public string ValueList { get; set; }

        public static OptionArgumentInfo Create(MemberInfo memberInfo, OptionAttribute option)
        {
            if (option == null)
            {
                return null;
            }

            var instance = new OptionArgumentInfo()
            {
                Name         = option.LongName,
                Shortcut     = option.ShortName,
                Required     = option.Required,
                DefaultValue = option.Default == null ? null : option.Default.ToString(),
                Description  = option.HelpText,
            };

            return instance;
        }
    }
}
