using System;
using DNX.Helpers.Console.CommandLine.Results;

namespace DNX.Helpers.Console.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// Class ParserResultException.
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    public class ExtendedParserResultException<T> : Exception
    {
        /// <summary>
        /// Gets the parserResult.
        /// </summary>
        /// <value>The failure parserResult.</value>
        public IExtendedParserResult<T> ExtendedParserResult { get; private set; }

        /// <summary>
        /// Gets a value indicating whether [help requested].
        /// </summary>
        /// <value><c>true</c> if [help requested]; otherwise, <c>false</c>.</value>
        public bool HelpRequested { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="extendedParserResult">The extended parser result.</param>
        /// <inheritdoc />
        public ExtendedParserResultException(IExtendedParserResult<T> extendedParserResult)
            : this(extendedParserResult, null)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="extendedParserResult">The extended parser result.</param>
        /// <param name="message">The message.</param>
        public ExtendedParserResultException(IExtendedParserResult<T> extendedParserResult, string message)
            : this(extendedParserResult, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Console.Exceptions.ParserResultException`1" /> class.
        /// </summary>
        /// <param name="extendedParserResult">The extended parser result.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <inheritdoc />
        public ExtendedParserResultException(IExtendedParserResult<T> extendedParserResult, string message, Exception innerException)
            : base(message, innerException)
        {
            ExtendedParserResult = extendedParserResult;
            HelpRequested        = false;  // TODO: Determine from ExtendedParserResult
        }
    }
}
