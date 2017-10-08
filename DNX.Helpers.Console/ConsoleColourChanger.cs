using System;

namespace DNX.Helpers.Console
{
    /// <summary>
    ///
    /// </summary>
    public enum ColorType
    {
        /// <summary>
        /// Refers to foreground colour
        /// </summary>
        Foreground,
        /// <summary>
        /// Refers to background colour
        /// </summary>
        Background
    }

    /// <summary>
    /// Class ConsoleColourChanger.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ConsoleColourChanger : IDisposable
    {
        private readonly ConsoleColor _oldColour;
        private readonly ColorType _oldColourType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleColourChanger"/> class.
        /// </summary>
        /// <param name="newColour">The new colour.</param>
        public ConsoleColourChanger(ConsoleColor newColour)
            : this(newColour, ColorType.Foreground)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleColourChanger"/> class.
        /// </summary>
        /// <param name="newColour">The new colour.</param>
        /// <param name="type">The type.</param>
        public ConsoleColourChanger(ConsoleColor newColour, ColorType type)
        {
            _oldColourType = type;
            _oldColour = GetColour(_oldColourType);

            SetColour(newColour, _oldColourType);
        }

        #region Static Methods

        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <returns>ConsoleColor.</returns>
        public static ConsoleColor GetColour()
        {
            return GetColour(ColorType.Foreground);
        }
        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>ConsoleColor.</returns>
        public static ConsoleColor GetColour(ColorType type)
        {
            switch (type)
            {
                case ColorType.Foreground:
                    return System.Console.ForegroundColor;
                case ColorType.Background:
                    return System.Console.BackgroundColor;
                default:
                    return System.Console.ForegroundColor;
            }
        }

        /// <summary>
        /// Sets the colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        public static void SetColour(ConsoleColor colour)
        {
            SetColour(colour, ColorType.Foreground);
        }
        /// <summary>
        /// Sets the colour.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="type">The type.</param>
        public static void SetColour(ConsoleColor colour, ColorType type)
        {
            switch (type)
            {
                case ColorType.Foreground:
                    System.Console.ForegroundColor = colour;
                    break;

                case ColorType.Background:
                    System.Console.BackgroundColor = colour;
                    break;
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SetColour(_oldColour, _oldColourType);
        }

        #endregion
    }
}
