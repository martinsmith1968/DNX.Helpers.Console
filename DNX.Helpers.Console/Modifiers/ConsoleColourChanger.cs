using System;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Modifiers
{
    /// <summary>
    /// Class ConsoleColorChanger.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ConsoleColourChanger : IColourChanger
    {
        /// <summary>
        /// The foreground Colour changer
        /// </summary>
        /// <value>The foreground.</value>
        public ForegroundColourChanger Foreground { get; private set; }

        /// <summary>
        /// The background Colour changer
        /// </summary>
        /// <value>The background.</value>
        public BackgroundColourChanger Background { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleColourChanger"/> class.
        /// </summary>
        /// <param name="foregroundColor">Colour of the foreground.</param>
        /// <param name="backgroundColor">Colour of the background.</param>
        public ConsoleColourChanger(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Foreground = new ForegroundColourChanger(foregroundColor);
            Background = new BackgroundColourChanger(backgroundColor);
        }

        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <value>The colour.</value>
        public ConsoleColor Colour
        {
            get { return Foreground.Colour; }
        }

        /// <summary>
        /// Changes the colour.
        /// </summary>
        /// <param name="newColour">The new colour.</param>
        public void ChangeColour(ConsoleColor newColour)
        {
            Foreground.ChangeColour(newColour);
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            Foreground.Dispose();
            Background.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Reset();
        }
    }
}
