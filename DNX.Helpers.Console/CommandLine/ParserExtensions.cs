using System.Collections.Generic;
using System.IO;
using CommandLine;
using DNX.Helpers.Console.Exceptions;
using DNX.Helpers.Console.Interfaces;
using DNX.Helpers.Strings;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserExtensions.
    /// </summary>
    public static class ParserExtensions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the Parser should throw an Exception if parsing fails
        /// </summary>
        /// <value><c>true</c> to throw on parse failure; otherwise, <c>false</c>.</value>
        public static bool ThrowOnParseFailure { get; set; }

        static ParserExtensions()
        {
            ResetSettings();
        }

        /// <summary>
        /// Resets the settings.
        /// </summary>
        public static void ResetSettings()
        {
            ThrowOnParseFailure = false;
        }

        /// <summary>|
        /// Parses the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> ParseAndValidate<T>(this Parser parser, string[] args)
            where T : new()
        {
            var expandedArgs = ExpandArgs(args);

            var result = parser.ParseArguments<T>(expandedArgs);

            if (ThrowOnParseFailure && !result.Ok())
            {
                throw new ParserResultException<T>(result.ErrorResult());
            }

            if (result.Ok())
            {
                ValidateInstance(result);
            }

            return result;
        }

        /// <summary>
        /// Expands the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> ExpandArgs(IEnumerable<string> args)
        {
            var expandedArgs = new List<string>();

            foreach (var arg in args)
            {
                if (arg.StartsWith("@"))
                {
                    var fileInfo = new FileInfo(arg.RemoveStartsWith("@"));
                    if (fileInfo.Exists)
                    {
                        expandedArgs.AddRange(File.ReadAllLines(fileInfo.FullName));
                    }
                }
                else
                {
                    expandedArgs.Add(arg);
                }
            }

            return expandedArgs;
        }

        /// <summary>
        /// Custom validation on the arguments options instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        public static void ValidateInstance<T>(ParserResult<T> result)
            where T : new()
        {
            var validator = result.Result().Value as IPostParseValidator;
            if (validator != null)
            {
                validator.Validate();
            }
        }

        #region Verb Extensions

        private static ParserResult<object> CheckVerbResult(ParserResult<object> result)
        {
            if (ThrowOnParseFailure && !result.Ok())
            {
                throw new ParserResultException(result.ErrorResult());
            }

            if (result.Ok())
            {
                ValidateInstance(result);
            }

            return result;
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <typeparam name="T15">The type of the T15.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        /// <summary>
        /// Parses the and validate.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <typeparam name="T7">The type of the t7.</typeparam>
        /// <typeparam name="T8">The type of the t8.</typeparam>
        /// <typeparam name="T9">The type of the t9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <typeparam name="T15">The type of the T15.</typeparam>
        /// <typeparam name="T16">The type of the T16.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Parser parser, IEnumerable<string> args)
        {
            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(ExpandArgs(args));

            return CheckVerbResult(result);
        }

        #endregion
    }
}
