using CommandLine;

namespace DNX.Helpers.Console.CommandLine.Results
{
    /// <summary>
    /// Class ExtendedParserResult.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DNX.Helpers.Console.CommandLine.Results.IExtendedParserResult{T}" />
    public class ExtendedParserResult<T> : IExtendedParserResult<T>
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <value>The parser.</value>
        public Parser Parser { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="!:IExtendedParserResult" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get { return Result.Ok(); } }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public ParserResult<T> Result { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedParserResult{T}"/> class.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="parser">The parser.</param>
        public ExtendedParserResult(ParserResult<T> result, Parser parser)
        {
            Result = result;
            Parser = parser;
        }
    }
}
