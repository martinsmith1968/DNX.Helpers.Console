using CommandLine;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserSettingsExtensions.
    /// </summary>
    public static class ParserSettingsExtensions
    {
        /// <summary>
        /// Resets the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public static void Reset(this ParserSettings settings)
        {
            ParserExtendedSettings.Reset();
        }

        /// <summary>
        /// Set whether the Parser throws an Exception or not during Parse Failure
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void ShouldThrowOnParseFailure(this ParserSettings settings, bool value)
        {
            ParserExtendedSettings.ThrowOnParseFailure = value;
        }
    }
}
