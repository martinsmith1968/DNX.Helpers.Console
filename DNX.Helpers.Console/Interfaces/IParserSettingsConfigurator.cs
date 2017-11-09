using CommandLine;

namespace DNX.Helpers.Console.Interfaces
{
    /// <summary>
    /// Interface IParserSettingsConfigurator
    /// </summary>
    public interface IParserSettingsConfigurator
    {
        /// <summary>
        /// Configures the Parser Settings
        /// </summary>
        /// <param name="settings">The settings.</param>
        void SettingsConfigurator(ParserSettings settings);
    }
}
