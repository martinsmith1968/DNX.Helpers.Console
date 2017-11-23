using System;
using System.Collections.Generic;
using CommandLine;

namespace DNX.Helpers.Console.CommandLine.Results
{
    /// <summary>
    /// Class ExtendedParserResultExtensions.
    /// </summary>
    public static class ExtendedParserResultExtensions
    {
        /// <summary>
        /// Withes the not parsed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="action">The action.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static IExtendedParserResult<T> WithNotParsed<T>(this IExtendedParserResult<T> result, Action<IEnumerable<Error>> action)
        {
            return result.Result.WithNotParsed(action)
                .CreateExtendedResult(result.Parser);
        }

        /// <summary>
        /// Withes the parsed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="action">The action.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static IExtendedParserResult<object> WithParsed<T>(this IExtendedParserResult<object> result, Action<T> action)
        {
            return result.Result.WithParsed(action)
                .CreateExtendedResult(result.Parser);
        }

        /// <summary>
        /// Withes the parsed.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <param name="action">The action.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static IExtendedParserResult<T> WithParsed<T>(this IExtendedParserResult<T> result, Action<T> action)
        {
            return result.Result.WithParsed(action)
                .CreateExtendedResult(result.Parser);
        }
    }
}
