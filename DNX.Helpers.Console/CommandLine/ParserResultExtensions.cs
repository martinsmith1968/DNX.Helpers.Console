using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserResultExtensions.
    /// </summary>
    public static class ParserResultExtensions
    {
        /// <summary>
        /// Oks the specified result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool Ok<T>(this ParserResult<T> result)
        {
            return result.Result() != null;
        }

        /// <summary>
        /// Results the specified result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>Parsed&lt;T&gt;.</returns>
        public static Parsed<T> Result<T>(this ParserResult<T> result)
        {
            return result as Parsed<T>;
        }

        /// <summary>
        /// Errors the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>NotParsed&lt;T&gt;.</returns>
        public static NotParsed<T> ErrorResult<T>(this ParserResult<T> result)
        {
            return result as NotParsed<T>;
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>T.</returns>
        public static T GetArguments<T>(this ParserResult<T> result)
        {
            var successResult = result.Result();

            return successResult != null
                ? successResult.Value
                : default(T);
        }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>System.Collections.Generic.IEnumerable&lt;CommandLine.Error&gt;.</returns>
        public static IEnumerable<Error> GetErrors<T>(this ParserResult<T> result)
        {
            var errorResult = result.ErrorResult();

            return errorResult == null
                ? Enumerable.Empty<Error>()
                : errorResult.Errors;
        }
    }
}
