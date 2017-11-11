using System.Collections.Generic;
using System.Linq;
using CommandLine;
using DNX.Helpers.Console.Exceptions;
using DNX.Helpers.Console.Interfaces;

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

        /// <summary>
        /// Custom validation on a parsed arguments instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        public static void ValidateInstance<T>(this Parsed<T> result)
            where T : new()
        {
            var validator = result.Value as IPostParseValidator;
            if (validator != null)
            {
                validator.Validate();
            }
        }

        /// <summary>
        /// Post processes the result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result">The result.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        /// <exception cref="ParserResultException{T}"></exception>
        internal static void PostProcessResult<T>(this ParserResult<T> result)
            where T : new()
        {
            if (ParserExtendedSettings.ThrowOnParseFailure && !result.Ok())
            {
                throw new ParserResultException<T>(result.ErrorResult());
            }

            if (result.Ok())
            {
                ValidateInstance(result.Result());
            }
        }
    }
}
