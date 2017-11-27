#pragma warning disable 1591
namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
    public interface IArgumentInfo
    {
        string Name { get; }

        string Description { get; }

        bool Required { get; }

        string DefaultValue { get; }
    }
}
