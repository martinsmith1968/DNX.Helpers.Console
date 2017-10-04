using System;

namespace DNX.CommandLine.Helpers.Exceptions
{
    public class ReturnCodeException : Exception
    {
        public int ReturnCode { get; private set; }

        public ReturnCodeException(int returnCode)
            : this(returnCode, null)
        {
        }

        public ReturnCodeException(int returnCode, string message)
            : this(returnCode, message, null)
        {
        }

        public ReturnCodeException(int returnCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ReturnCode = returnCode;
        }
    }
}
