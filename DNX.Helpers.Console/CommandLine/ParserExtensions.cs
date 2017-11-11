﻿// Code generated by a Template
using System.Collections.Generic;
using CommandLine;

namespace DNX.Helpers.Console.CommandLine
{
    /// <summary>
    /// Class ParserVerbExtensions.
    /// </summary>
    public static class ParserExtensions
    {
        /// <summary>
        /// Parses the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>ParserResult&lt;T&gt;.</returns>
        public static ParserResult<T> ParseAndValidate<T>(this Parser parser, IEnumerable<string> args)
            where T : new()
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <typeparam name="T15">The type of the T15.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(expandedArgs);

            result.PostProcessResult();

            return result;
        }

        /// <summary>
        /// Parses the specified Command arguments.
        /// </summary>
        /// <typeparam name="T1">The type of the T1.</typeparam>
        /// <typeparam name="T2">The type of the T2.</typeparam>
        /// <typeparam name="T3">The type of the T3.</typeparam>
        /// <typeparam name="T4">The type of the T4.</typeparam>
        /// <typeparam name="T5">The type of the T5.</typeparam>
        /// <typeparam name="T6">The type of the T6.</typeparam>
        /// <typeparam name="T7">The type of the T7.</typeparam>
        /// <typeparam name="T8">The type of the T8.</typeparam>
        /// <typeparam name="T9">The type of the T9.</typeparam>
        /// <typeparam name="T10">The type of the T10.</typeparam>
        /// <typeparam name="T11">The type of the T11.</typeparam>
        /// <typeparam name="T12">The type of the T12.</typeparam>
        /// <typeparam name="T13">The type of the T13.</typeparam>
        /// <typeparam name="T14">The type of the T14.</typeparam>
        /// <typeparam name="T15">The type of the T15.</typeparam>
        /// <typeparam name="T16">The type of the T16.</typeparam>
        /// <param name="parser">The parser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>CommandLine.ParserResult&lt;System.Object&gt;.</returns>
        public static ParserResult<object> ParseAndValidate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this Parser parser, IEnumerable<string> args)
        {
            var expandedArgs = args.Expand();

            var result = parser.ParseArguments<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(expandedArgs);

            result.PostProcessResult();

            return result;
        }
    }
}