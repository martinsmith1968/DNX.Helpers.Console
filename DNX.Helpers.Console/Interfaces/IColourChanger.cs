using System;

namespace DNX.Helpers.Console.Interfaces
{
    /// <summary>
    /// Interface IColourChanger
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IColourChanger : IDisposable
    {
        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <value>The colour.</value>
        ConsoleColor Colour { get; }

        /// <summary>
        /// Changes the colour.
        /// </summary>
        /// <param name="newColour">The new colour.</param>
        void ChangeColour(ConsoleColor newColour);

        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();
    }
}
