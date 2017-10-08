using System;

namespace DNX.CommandLine.Helpers.Exceptions
{
    /// <summary>
    /// Class ReturnCodeException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ReturnCodeException : Exception
    {
        /// <summary>
        /// Gets the return code.
        /// </summary>
        /// <value>The return code.</value>
        public int ReturnCode { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnCodeException"/> class.
        /// </summary>
        /// <param name="returnCode">The return code.</param>
        public ReturnCodeException(int returnCode)
            : this(returnCode, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnCodeException"/> class.
        /// </summary>
        /// <param name="returnCode">The return code.</param>
        /// <param name="message">The message.</param>
        public ReturnCodeException(int returnCode, string message)
            : this(returnCode, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnCodeException"/> class.
        /// </summary>
        /// <param name="returnCode">The return code.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ReturnCodeException(int returnCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ReturnCode = returnCode;
        }
    }
}
