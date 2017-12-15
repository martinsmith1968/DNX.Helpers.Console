using System;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Console.Interfaces;

namespace DNX.Helpers.Console.Modifiers
{
    /// <summary>
    /// Class SingleColourChanger.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class SingleColourChanger : IColourChanger
    {
        /// <summary>
        /// The previous colour that will be reset
        /// </summary>
        /// <value>The colour of the previous.</value>
        public ConsoleColor PreviousColour { get; private set; }

        /// <summary>
        /// Gets the colour.
        /// </summary>
        /// <value>The colour.</value>
        public ConsoleColor Colour { get; set; }

        /// <summary>
        /// Gets the type of the colour.
        /// </summary>
        /// <value>The type of the colour.</value>
        public ColorType ColorType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleColourChanger" /> class.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="colorType">Type of the colour.</param>
        public SingleColourChanger(ConsoleColor colour, ColorType colorType)
        {
            PreviousColour = ConsoleHelper.GetColor(colorType);
            ColorType      = colorType;

            ChangeColour(colour);
        }

        /// <summary>
        /// Changes the colour.
        /// </summary>
        /// <param name="newColour">The new colour.</param>
        public void ChangeColour(ConsoleColor newColour)
        {
            Colour = newColour;
            ConsoleHelper.SetColor(Colour, ColorType);
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            ChangeColour(PreviousColour);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            Reset();
        }
    }
}
