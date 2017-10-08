using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Strings.Interpolation;

namespace DNX.Helpers.Console
{
    /// <summary>
    /// Enum DisplayAtAlignment
    /// </summary>
    public enum DisplayAtAlignment
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,
        /// <summary>
        /// The right
        /// </summary>
        Right,
        /// <summary>
        /// The centre
        /// </summary>
        Centre
    }

    /// <summary>
    ///
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        ///
        /// </summary>
        public static void DisplayHeader(AssemblyDetails assemblyDetails)
        {
            DisplayHeader(assemblyDetails, System.Console.Out);
        }

        /// <summary>
        /// Displays the header.
        /// </summary>
        /// <param name="assemblyDetails">The assembly details.</param>
        /// <param name="headers">The headers.</param>
        public static void DisplayHeader(AssemblyDetails assemblyDetails, IList<string> headers)
        {
            DisplayHeader(assemblyDetails, headers, System.Console.Out);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="assemblyDetails"></param>
        /// <param name="writer"></param>
        public static void DisplayHeader(AssemblyDetails assemblyDetails, TextWriter writer)
        {
            var headers = new[]
            {
                "{Name} v{version.Major}.{version.Minor} - {Description}",
                "{Copyright}"
            };

            DisplayHeader(assemblyDetails, headers, writer);
        }

        /// <summary>
        /// Displays the header.
        /// </summary>
        /// <param name="assemblyDetails">The assembly details.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="writer">The writer.</param>
        public static void DisplayHeader(AssemblyDetails assemblyDetails, IList<string> headers, TextWriter writer)
        {
            var instances = new[]
            {
                new NamedInstance(assemblyDetails),
                new NamedInstance(assemblyDetails.Version, "version"),
                new NamedInstance(assemblyDetails.AssemblyName, "assemblyName"),
            };

            headers.ToList()
                .ForEach(h => writer.WriteLine(h.InterpolateWithAll(instances)));
        }

        /// <summary>
        ///
        /// </summary>
        public static void Display()
        {
            Display(null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public static void Display(string s)
        {
            Display(s, true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="newline"></param>
        public static void Display(string s, bool newline)
        {
            Display(s, System.Console.Out, newline);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wtr"></param>
        public static void Display(string s, TextWriter wtr)
        {
            Display(s, wtr, true);
        }

        /// <summary>
        /// Displays the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="wtr">The WTR.</param>
        /// <param name="newline">The newline.</param>
        public static void Display(string s, TextWriter wtr, bool newline)
        {
            if (newline)
            {
                wtr.WriteLine(s);
            }
            else
            {
                wtr.Write(s);
            }
        }

        /// <summary>
        /// Displays at.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        public static void DisplayAt(int y, int x, string text)
        {
            DisplayAt(y, x, text, DisplayAtAlignment.Left);
        }

        /// <summary>
        /// Displays at.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        /// <param name="text">The text.</param>
        /// <param name="alignment">The alignment.</param>
        public static void DisplayAt(int y, int x, string text, DisplayAtAlignment alignment)
        {
            if (!string.IsNullOrEmpty(text))
            {
                switch (alignment)
                {
                    case DisplayAtAlignment.Right:
                        x -= text.Length;
                        break;

                    case DisplayAtAlignment.Centre:
                        x -= (text.Length / 2);
                        break;
                }
            }

            MoveTo(y, x);
            System.Console.Out.Write(text);
        }

        /// <summary>
        /// Moves to.
        /// </summary>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public static void MoveTo(int y, int x)
        {
            System.Console.CursorLeft = x;
            System.Console.CursorTop = y;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        public static void DisplayError(string s)
        {
            DisplayError(s, true);
        }

        /// <summary>
        /// Displays the error.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="changeColour">if set to <c>true</c> [change colour].</param>
        public static void DisplayError(string s, bool changeColour)
        {
            if (changeColour)
            {
                using (new ConsoleColourChanger(ConsoleColor.Red, ColorType.Foreground))
                {
                    Display(s, System.Console.Error);
                }
            }
            else
            {
                Display(s, System.Console.Error);
            }
        }
    }
}
