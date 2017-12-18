using System;
using System.Linq;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Console.Text.Items;
using DNX.Helpers.Strings;

namespace DNX.Helpers.Console.Text
{
    /// <summary>
    /// Class FormattedText.
    /// </summary>
    /// <seealso cref="DNX.Helpers.Console.Interfaces.IConsoleTextItem" />
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
        /// Converts the specified raw text to console text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IConsoleText.</returns>
        public static IConsoleTextItem ToConsoleText(this string text)
        {
            return Parse(text);
        }

        /// <summary>
        /// Parses the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IList&lt;IConsoleText&gt;.</returns>
        public static IConsoleTextItem Parse(string text)
        {
            return Parse(ref text, null);
        }

        /// <summary>
        /// Parses the specified text to an IConsoleText.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="endIdent">The end ident.</param>
        /// <returns>DNX.Helpers.Console.Interfaces.IConsoleText.</returns>
        public static IConsoleTextItem Parse(ref string text, string endIdent)
        {
            var collection = new TextItemCollection();

            do
            {
                var consoleTextItem = GetCurrentConsoleTextItem(text);
                if (consoleTextItem == null)
                    break;

                if (!string.IsNullOrEmpty(endIdent))
                {
                    if (consoleTextItem.Type == ConsoleTextItemType.EndMarker)
                    {
                        if (consoleTextItem.Identifier != endIdent)
                        {
                            throw new Exception(string.Format("Invalid Console Text - Expected end marker: {0}, found {1}", endIdent, consoleTextItem.Identifier));
                        }

                        break;
                    }
                }

                var item = ParseItem(ref text);
                if (item == null && !string.IsNullOrEmpty(text))
                {
                    throw new Exception(string.Format("Invalid Console Text - Unexpected or unknown Tag ident: {0}:{1}", consoleTextItem.Type, consoleTextItem.Identifier));
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
        private static IConsoleTextItem ParseItem(ref string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            if (ColouredTextItem.CanParse(text))
            {
                return ColouredTextItem.Parse(ref text);
            }

            if (PlainTextItem.CanParse(text))
            {
                return PlainTextItem.Parse(ref text);
            }

            return null;
        }

        /// <summary>
        /// Gets the current console text item.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ConsoleTextItem.</returns>
        internal static ConsoleTextItemDetails GetCurrentConsoleTextItem(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (!text.StartsWith(MarkerTagStart))
                {
                    return ConsoleTextItemDetails.Create(ConsoleTextItemType.PlainText);
                }

                var ident = GetCurrentIdent(text);

                return !string.IsNullOrEmpty(ident) && ident.StartsWith(MarkerTerminatorPrefix)
                    ? ConsoleTextItemDetails.Create(ConsoleTextItemType.EndMarker, ident.RemoveStartsWith(MarkerTerminatorPrefix))
                    : ConsoleTextItemDetails.Create(ConsoleTextItemType.StartMarker, ident);
            }

            return null;
        }

        /// <summary>
        /// Determines whether [is head a text marker] [the specified text].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if [is head a text marker] [the specified text]; otherwise, <c>false</c>.</returns>
        internal static bool IsHeadATextMarker(string text)
        {
            return !string.IsNullOrEmpty(text) && text.StartsWith(MarkerTagStart);
        }

        /// <summary>
        /// Gets the text to next marker.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        internal static string GetCurrentPlainText(string text)
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
        internal static string GetCurrentIdent(string text)
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
        internal static string GetNextMarkerIdent(string text)
        {
            const string identifierName = "identifier";

            var markerText = text.ParseFirstMatchToDictionary(string.Format(@"\[\[(?<{0}>[^\]]+)\]\]", identifierName));
            if (!markerText.ContainsKey(identifierName) || string.IsNullOrEmpty(markerText[identifierName]))
            {
                return null;
            }

            var ident = markerText[identifierName];

            return ident;
        }

        /// <summary>
        /// Removes the plain text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="plainText">The plain text.</param>
        /// <returns>System.String.</returns>
        internal static string RemovePlainText(this string text, string plainText)
        {
            return text.RemoveStartsWith(plainText);
        }

        /// <summary>
        /// Removes the start marker by ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ident">The ident.</param>
        /// <returns>System.String.</returns>
        internal static string RemoveStartMarkerByIdent(this string text, string ident)
        {
            return text.RemoveStartsWith(string.Format("{0}{1}{2}", MarkerTagStart, ident, MarkerTagEnd));
        }

        /// <summary>
        /// Removes the end marker by ident.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="ident">The ident.</param>
        /// <returns>System.String.</returns>
        internal static string RemoveEndMarkerByIdent(this string text, string ident)
        {
            return text.RemoveStartsWith(string.Format("{0}/{1}{2}", MarkerTagStart, ident, MarkerTagEnd));
        }
    }
}
