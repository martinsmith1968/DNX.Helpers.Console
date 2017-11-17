#pragma warning disable 1591

namespace DNX.Helpers.Console.CommandLine.Templating.DotLiquid
{
    public static class TextPadder
    {
        // ReSharper disable InconsistentNaming
        public static string padright40(string input)
        {
            return padright(input, 40);
        }

        public static string padright(string input, int length)
        {
            return (input ?? string.Empty).PadRight(length);
        }

        public static string padleft(string input, int length)
        {
            return (input ?? string.Empty).PadLeft(length);
        }

        public static string padcentre(string input, int length)
        {
            return (input ?? string.Empty).PadLeft(length / 2).PadRight(length);
        }
    }
}
