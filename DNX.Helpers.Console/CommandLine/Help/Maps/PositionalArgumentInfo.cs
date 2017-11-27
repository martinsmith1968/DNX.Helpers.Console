using System.Reflection;
using CommandLine;

#pragma warning disable 1591
namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    public class PositionalArgumentInfo : IArgumentInfo
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public bool Optional { get { return !Required; } }

        public string DefaultValue { get; set; }

        public static PositionalArgumentInfo Create(MemberInfo memberInfo, ValueAttribute value)
        {
            var instance = new PositionalArgumentInfo()
            {
                Name         = memberInfo.Name,
                Description  = value.HelpText,
                Position     = value.Index,
                Required     = value.Required,
                DefaultValue = value.Default == null ? null : value.Default.ToString()
            };

            return instance;
        }
    }
}
