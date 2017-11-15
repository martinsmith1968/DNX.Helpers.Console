using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Console.CommandLine.Arguments;
using DNX.Helpers.Reflection;
using DotLiquid;

namespace DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    public static class OptionPadder
    {
        private static string PadTo(string input, int length)
        {
            return (input ?? string.Empty).PadRight(length);
        }

        public static string padoptionby(Context context, string input, int padLength)
        {
            var maxLength = context.MaxIterations;

            var environments = context.Environments[0];
            var parser = environments["Parser"] as Hash;
            var optionsDict = parser["Options"] as List<IDictionary<string, object>>;
            var options = optionsDict != null && optionsDict.Any()
                ? optionsDict.Select(o => o.ToInstance<OptionArgument>()).ToList()
                : Enumerable.Empty<OptionArgument>();

            var maxOptionShortcut = options
                .Max(o => o.Shortcut.Length);

            var maxOptionName = options
                .Max(o => string.IsNullOrEmpty(o.Name) ? 0 : o.Name.Length);

            return PadTo(input, maxOptionShortcut + maxOptionName + padLength);
        }

        public static string padoptionby2(Context context, string input)
        {
            return padoptionby(context, input, 2);
        }

        public static string padoptionby4(Context context, string input)
        {
            return padoptionby(context, input, 4);
        }

        public static string pad8(string input)
        {
            return PadTo(input, 8);
        }
        public static string pad12(string input)
        {
            return PadTo(input, 12);
        }
        public static string pad16(string input)
        {
            return PadTo(input, 16);
        }
        public static string pad20(string input)
        {
            return PadTo(input, 20);
        }
    }
}
