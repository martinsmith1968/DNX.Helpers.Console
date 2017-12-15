using System;
using DNX.Helpers.Console.Enums;

namespace DNX.Helpers.Console.Modifiers
{
    /// <summary>
    /// Class ForegroundColourChanger.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Modifiers.SingleColourChanger" />
    public class ForegroundColourChanger : SingleColourChanger
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForegroundColourChanger"/> class.
        /// </summary>
        /// <param name="colour">The colour.</param>
        public ForegroundColourChanger(ConsoleColor colour)
            : base(colour, ColorType.Foreground)
        {
        }
    }
}
