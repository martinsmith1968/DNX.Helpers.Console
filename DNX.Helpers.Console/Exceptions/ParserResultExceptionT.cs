using System;
using CommandLine;

namespace DNX.Helpers.Console.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Class ParserResultException.
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class ParserResultException<T> : Exception
    {
        /// <summary>
        /// Gets the failure result.
        /// </summary>
        /// <value>The failure result.</value>
        public NotParsed<T> FailureResult { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [help requested].
        /// </summary>
        /// <value><c>true</c> if [help requested]; otherwise, <c>false</c>.</value>
        public bool HelpRequested { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        public ParserResultException(NotParsed<T> failureResult)
            : this(failureResult, null)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="failureResult">The failure result.</param>
        /// <param name="message">The message.</param>
        public ParserResultException(NotParsed<T> failureResult, string message)
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
        public ParserResultException(NotParsed<T> failureResult, string message, Exception innerException)
            : base(message, innerException)
        {
            FailureResult = failureResult;
            HelpRequested = false; // TODO: Need to calculate this
        }
    }
}
