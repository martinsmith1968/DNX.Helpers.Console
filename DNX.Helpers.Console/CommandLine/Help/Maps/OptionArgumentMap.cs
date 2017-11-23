#pragma warning disable 1591

namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    public class OptionArgumentMap
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
    }
}
