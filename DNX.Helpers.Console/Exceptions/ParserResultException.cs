using System;
using CommandLine;

namespace DNX.CommandLine.Helpers.Exceptions
{
    /// <summary>
    /// Class ParserResultException.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Exception" />
    public class ParserResultException<T> : Exception
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public ParserResult<T> Result { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserResultException{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        public ParserResultException(ParserResult<T> result)
            : this(result, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserResultException{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="message">The message.</param>
        public ParserResultException(ParserResult<T> result, string message)
            : this(result, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserResultException{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParserResultException(ParserResult<T> result, string message, Exception innerException)
            : base(message, innerException)
        {
            Result = result;
        }
    }
}
