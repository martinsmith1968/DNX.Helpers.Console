using System;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Modifiers
{
    /// <summary>
    /// Class ColourChanger.
    /// </summary>
    public static class ColourChangerHelper
    {
        /// <summary>
        /// Creates the specified colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="colorType">Type of the color.</param>
        /// <returns>IColourChanger.</returns>
        public static IColourChanger Create(ConsoleColor colour, ColorType colorType)
        {
            return new SingleColourChanger(colour, colorType);
        }

        /// <summary>
        /// Creates the specified foreground colour.
        /// </summary>
        /// <param name="foregroundColour">The foreground colour.</param>
        /// <param name="backgroundColour">The background colour.</param>
        /// <returns>IColourChanger.</returns>
        public static IColourChanger Create(ConsoleColor foregroundColour, ConsoleColor backgroundColour)
        {
            return new ConsoleColourChanger(foregroundColour, backgroundColour);
        }
    }
}
