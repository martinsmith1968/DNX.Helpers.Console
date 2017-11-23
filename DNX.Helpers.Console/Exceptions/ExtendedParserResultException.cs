using System;
using CommandLine;
using DNX.Helpers.Console.CommandLine.Results;

namespace DNX.Helpers.Console.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Class ParserResultException.
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class ExtendedParserResultException : ExtendedParserResultException<object>
    {
        /// <summary>
        /// Gets the failure result as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public NotParsed<T> GetFailureResultAs<T>()
            where T : class
        {
            return ExtendedParserResult.Result as NotParsed<T>;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        /// <inheritdoc />
        public ExtendedParserResultException(ExtendedParserResult<object> failureResult)
            : this(failureResult, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        /// <param name="message">The message.</param>
        /// <inheritdoc />
        public ExtendedParserResultException(ExtendedParserResult<object> failureResult, string message)
            : this(failureResult, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <inheritdoc />
        public ExtendedParserResultException(ExtendedParserResult<object> failureResult, string message, Exception innerException)
            : base(failureResult, message, innerException)
        {
        }
    }
}
