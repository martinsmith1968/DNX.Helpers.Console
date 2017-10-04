using System;
using CommandLine;

namespace DNX.CommandLine.Helpers.Exceptions
{
    public class ParserResultException<T> : Exception
    {
        public ParserResult<T> Result { get; private set; }

        public ParserResultException(ParserResult<T> result)
            : this(result, null)
        {
        }

        public ParserResultException(ParserResult<T> result, string message)
            : this(result, message, null)
        {
        }

        public ParserResultException(ParserResult<T> result, string message, Exception innerException)
            : base(message, innerException)
        {
            Result = result;
        }
    }
}
