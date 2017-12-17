using System;
using System.Linq;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Strings;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class FormattedText.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleText" />
    public static class ConsoleTextHelper
    {
        /// <summary>
        /// The marker tag start text
        /// </summary>
        public static string MarkerTagStart = "[[";

        /// <summary>
        /// The marker tag end text
        /// </summary>
        public static string MarkerTagEnd = "]]";

        /// <summary>
        /// The marker terminator prefix text
        /// </summary>
        public static string MarkerTerminatorPrefix = "/";

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IList&lt;IConsoleText&gt;.</returns>
        public static IConsoleText Parse(string text)
        {
            return Parse(ref text, null);
        }

        /// <summary>
        /// Parses the specified text to an IConsoleText.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="endIdent">The end ident.</param>
        /// <returns>DNX.Helpers.Console.Interfaces.IConsoleText.</returns>
        public static IConsoleText Parse(ref string text, string endIdent)
        {
            var collection = new ConsoleTextCollection();

            do
            {
                var consoleTextItem = GetCurrentConsoleTextItem(text);
                if (consoleTextItem == null)
                    break;

                if (!string.IsNullOrEmpty(endIdent))
                {
                    if (consoleTextItem.Type == ConsoleTextItemType.EndMarker)
                    {
                        if (consoleTextItem.Ident != endIdent)
                        {
                            throw new Exception(string.Format("Invalid Console Text - Expected end marker: {0}, found {1}", endIdent, consoleTextItem.Ident));
                        }

                        break;
                    }
                }

                var item = ParseItem(ref text);
                if (item == null && !string.IsNullOrEmpty(text))
                {
                    throw new Exception(string.Format("Invlaid Console Text - Unexpected or unknown Tag ident: {0}:{1}", consoleTextItem.Type, consoleTextItem.Ident));
                }


                if (item != null)
                {
                    collection.Parts.Add(item);
                }
            } while (!string.IsNullOrEmpty(text));

            return collection.Parts.Any()
                ? collection
                : null;
        }

        /// <summary>
        /// Parses the item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>DNX.Helpers.Console.Interfaces.IConsoleText.</returns>
        private static IConsoleText ParseItem(ref string text)
        {
            if (ColouredText.CanParse(text))
            {
                return ColouredText.Parse(ref text);
            }

            if (PlainText.CanParse(text))
            {
                return PlainText.Parse(ref text);
            }

            return null;
        }

        /// <summary>
        /// Gets the current console text item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ConsoleTextItem.</returns>
        public static ConsoleTextItem GetCurrentConsoleTextItem(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (!text.StartsWith(MarkerTagStart))
                {
                    return ConsoleTextItem.Create(ConsoleTextItemType.PlainText);
                }

                var ident = GetCurrentIdent(text);

                return !string.IsNullOrEmpty(ident) && ident.StartsWith(MarkerTerminatorPrefix)
                    ? ConsoleTextItem.Create(ConsoleTextItemType.EndMarker, ident.RemoveStartsWith(MarkerTerminatorPrefix))
                    : ConsoleTextItem.Create(ConsoleTextItemType.StartMarker, ident);
            }

            return null;
        }

        /// <summary>
        /// Determines whether [is head a text marker] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if [is head a text marker] [the specified text]; otherwise, <c>false</c>.</returns>
        public static bool IsHeadATextMarker(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(MarkerTagStart);
        }

        /// <summary>
        /// Gets the text to next marker.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string GetCurrentPlainText(string text)
        {
            if (IsHeadATextMarker(text))
            {
                return null;
            }

            return !string.IsNullOrEmpty(text) && text.Contains(MarkerTagStart)
                ? text.Before(MarkerTagStart)
                : text;
        }

        /// <summary>
        /// Gets the current ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string GetCurrentIdent(string text)
        {
            if (!IsHeadATextMarker(text))
            {
                return null;
            }

            return GetNextMarkerIdent(text);
        }

        /// <summary>
        /// Gets the next marker ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        public static string GetNextMarkerIdent(string text)
        {
            var markerText = text.ParseFirstMatchToDictionary(@"\[\[(?<ident>[^\]]+)\]\]");
            if (!markerText.ContainsKey("ident") || string.IsNullOrEmpty(markerText["ident"]))
            {
                return null;
            }

            var ident = markerText["ident"];

            return ident;
        }

        /// <summary>
        /// Removes the plain text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="plainText">The plain text.</param>
        /// <returns>System.String.</returns>
        public static string RemovePlainText(this string text, string plainText)
        {
            return text.RemoveStartsWith(plainText);
        }

        /// <summary>
        /// Removes the start marker by ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ident">The ident.</param>
        /// <returns>System.String.</returns>
        public static string RemoveStartMarkerByIdent(this string text, string ident)
        {
            return text.RemoveStartsWith(string.Format("{0}{1}{2}", MarkerTagStart, ident, MarkerTagEnd));
        }

        /// <summary>
        /// Removes the end marker by ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ident">The ident.</param>
        /// <returns>System.String.</returns>
        public static string RemoveEndMarkerByIdent(this string text, string ident)
        {
            return text.RemoveStartsWith(string.Format("{0}/{1}{2}", MarkerTagStart, ident, MarkerTagEnd));
        }
    }
}
