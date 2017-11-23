#pragma warning disable 1591
namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    public class PositionalArgumentMap
    {
        public int Position { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public bool Optional { get { return !Required; } }
    }
}
