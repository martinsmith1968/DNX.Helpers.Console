using System;
using CommandLine;

namespace DNX.Helpers.Console.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Class ParserResultException.
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class ParserResultException : Exception
    {
        /// <summary>
        /// Gets the failure result.
        /// </summary>
        /// <value>The failure result.</value>
        public object FailureResult { get; private set; }

        /// <summary>
        /// Gets the failure result as.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>T.</returns>
        public NotParsed<T> GetFailureResultAs<T>()
            where T : class
        {
            return FailureResult as NotParsed<T>;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        public ParserResultException(object failureResult)
            : this(failureResult, null)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        /// <param name="message">The message.</param>
        public ParserResultException(object failureResult, string message)
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
        public ParserResultException(object failureResult, string message, Exception innerException)
            : base(message, innerException)
        {
            FailureResult = failureResult;
        }
    }
}
