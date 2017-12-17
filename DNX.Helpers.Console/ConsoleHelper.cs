using System;
using System.Drawing;
using System.IO;
using System.Threading;
using DNX.Helpers.Console.Enums;
using DNX.Helpers.Strings.Interpolation;

namespace DNX.Helpers.Console
{
    /// <summary>
    ///
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// The press any key text
        /// </summary>
        public const string PressAnyKeyText = "Press any key to continue...";

        /// <summary>
        /// The press any key timeout text
        /// </summary>
        public const string PressAnyKeyTimeoutText = "Press any key to continue (or wait {timeout.TotalSeconds} seconds)...";

        /// <summary>
        /// Clears the input keys.
        /// </summary>
        public static void ClearInputKeys()
        {
            while (System.Console.KeyAvailable)
            {
                System.Console.ReadKey(true);
            }
        }

        /// <summary>
        /// Gets the size of the console.
        /// </summary>
        /// <param name="defaultWidth">The default width.</param>
        /// <param name="defaultHeight">The default height.</param>
        /// <returns>Size.</returns>
        public static Size GetConsoleSize(int defaultWidth = 80, int defaultHeight = 25)
        {
            var size = new Size
            {
                Height = System.Console.IsOutputRedirected ? defaultHeight : System.Console.WindowHeight,
                Width = System.Console.IsOutputRedirected ? defaultWidth : System.Console.WindowWidth
            };

            return size;
        }

        /// <summary>
        /// Get the current console output window width
        /// </summary>
        /// <param name="defaultWidth"></param>
        /// <returns></returns>
        public static int GetConsoleWidth(int defaultWidth = 80)
        {
            return GetConsoleSize(defaultWidth: defaultWidth).Width;
        }

        /// <summary>
        /// Get the current console output window width
        /// </summary>
        /// <param name="defaultHeight"></param>
        /// <returns></returns>
        public static int GetConsoleHeight(int defaultHeight = 25)
        {
            return GetConsoleSize(defaultHeight: defaultHeight).Height;
        }

        /// <summary>
        /// Pauses until a key is pressed
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        /// <returns>PauseResult.</returns>
        public static PauseResult Pause(this TextWriter textWriter)
        {
            return textWriter.Pause(PressAnyKeyText);
        }

        /// <summary>
        /// Pauses until a key is pressed
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        /// <param name="text">The text.</param>
        /// <returns>PauseResult.</returns>
        public static PauseResult Pause(this TextWriter textWriter, string text)
        {
            return textWriter.Pause(text, null);
        }

        /// <summary>
        /// Pauses until a key is pressed or the timeout expires
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>PauseResult.</returns>
        public static PauseResult Pause(this TextWriter textWriter, TimeSpan timeout)
        {
            return textWriter.Pause(PressAnyKeyTimeoutText, timeout);
        }

        /// <summary>
        /// Pauses until a key is pressed or the timeout expires
        /// </summary>
        /// <param name="textWriter">The text writer.</param>
        /// <param name="text">The text.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>PauseResult.</returns>
        public static PauseResult Pause(this TextWriter textWriter, string text, TimeSpan? timeout)
        {
            var pauseText = timeout.HasValue
                ? text.InterpolateWith(timeout.Value, "timeout")
                : text;

            textWriter.Write(pauseText);

            ClearInputKeys();

            if (!timeout.HasValue)
            {
                System.Console.ReadKey(true);

                return PauseResult.KeyPressed;
            }

            var timeoutLimit = DateTime.UtcNow.Add(timeout.Value);
            while (DateTime.UtcNow < timeoutLimit)
            {
                if (System.Console.KeyAvailable)
                {
                    return PauseResult.KeyPressed;
                }

                Thread.Sleep(100);
            }

            return PauseResult.Timeout;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="colorType">Type of the color.</param>
        /// <returns>ConsoleColor.</returns>
        public static ConsoleColor GetColor(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Background:
                    return System.Console.BackgroundColor;
                default:
                    return System.Console.ForegroundColor;
            }
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="colorType">Type of the color.</param>
        public static void SetColor(ConsoleColor color, ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Background:
                    System.Console.BackgroundColor = color;
                    break;
                default:
                    System.Console.ForegroundColor = color;
                    break;
            }
        }
    }
}
