using CommandLine;

namespace DNX.Helpers.Console.CommandLine.Results
{
    /// <summary>
    /// Interface IExtendedParserResult
    /// </summary>
    public interface IExtendedParserResult<T>
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <value>The parser.</value>
        Parser Parser { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IExtendedParserResult{T}"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        bool Success { get; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        ParserResult<T> Result { get; }
    }
}
