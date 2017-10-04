using System;

namespace DNX.Helpers.Console
{
    /// <summary>
    ///
    /// </summary>
    public enum ColorType
    {
        Foreground,
        Background
    }

    /// <summary>
    /// Class ConsoleColourChanger.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ConsoleColourChanger : IDisposable
    {
        private readonly ConsoleColor oldColour;
        private readonly ColorType oldColourType;

        public ConsoleColourChanger(ConsoleColor newColour)
            : this(newColour, ColorType.Foreground)
        {
        }

        public ConsoleColourChanger(ConsoleColor newColour, ColorType type)
        {
            oldColourType = type;
            oldColour = GetColour(oldColourType);

            SetColour(newColour, oldColourType);
        }

        #region Static Methods

        public static ConsoleColor GetColour()
        {
            return GetColour(ColorType.Foreground);
        }
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

        public static void SetColour(ConsoleColor colour)
        {
            SetColour(colour, ColorType.Foreground);
        }
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

        public void Dispose()
        {
            SetColour(oldColour, oldColourType);
        }

        #endregion
    }
}
