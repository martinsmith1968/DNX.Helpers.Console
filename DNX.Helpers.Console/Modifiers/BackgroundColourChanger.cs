using System;
using DNX.Helpers.Console.Enums;

namespace DNX.Helpers.Console.Modifiers
{
    /// <summary>
    /// Class BackgroundColorChanger.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Modifiers.SingleColourChanger" />
    public class BackgroundColourChanger : SingleColourChanger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundColourChanger"/> class.
        /// </summary>
        /// <param name="colour">The color.</param>
        public BackgroundColourChanger(ConsoleColor colour)
            : base(colour, ColorType.Background)
        {
        }
    }
}
