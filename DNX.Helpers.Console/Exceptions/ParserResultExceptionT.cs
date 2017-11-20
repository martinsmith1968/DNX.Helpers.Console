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
        /// Gets the result.
        /// </summary>
        /// <value>The failure result.</value>
        public ParserResult<T> Result { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [help requested].
        /// </summary>
        /// <value><c>true</c> if [help requested]; otherwise, <c>false</c>.</value>
        public bool HelpRequested { get; private set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="result">The failure result.</param>
        public ParserResultException(ParserResult<T> result)
            : this(result, null)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="result">The failure result.</param>
        /// <param name="message">The message.</param>
        public ParserResultException(ParserResult<T> result, string message)
            : this(result, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="result">The failure result.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <inheritdoc />
        public ParserResultException(ParserResult<T> result, string message, Exception innerException)
            : base(message, innerException)
        {
            Result        = result;
            HelpRequested = false; // TODO: Need to calculate this
        }
    }
}
