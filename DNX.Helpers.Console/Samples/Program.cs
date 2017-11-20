using System;
using CommandLine;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console;
using DNX.Helpers.Console.CommandLine;
using DNX.Helpers.Console.CommandLine.Help;
using DNX.Helpers.Console.CommandLine.Results;
using DNX.Helpers.Console.Exceptions;

namespace SampleApp
{
    /// <summary>
    /// Program controller class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Int32.</returns>
        private static int Main(string[] args)
        {
            try
            {
                var result = ParserHelper.GetParserAndParse<Arguments>(args)
                    .WithParsed(Run);

                var result2 = ParserHelper.GetParserAndParse<CommandA, CommandB, CommandC, CommandD>(args)
                    .WithParsed<CommandA>(a => a.Run())
                    .WithParsed<CommandB>(b => b.Run())
                    .WithParsed<CommandC>(c => c.Run())
                    .WithParsed<CommandD>(d => d.Run())
                    ;

                return result.Ok() ? 0 : 1;
            }
            catch (ParserResultException<Arguments> ex)
            {
                var helpText = HelpBuilder.BuildTemplatedHelpText(ex.Result);

                Console.Error.WriteLine(helpText);

                return 2;
            }
            catch (ParserResultException ex)
            {
                var failureA = ex.GetFailureResultAs<CommandA>();
                var failureB = ex.GetFailureResultAs<CommandB>();
                var failureC = ex.GetFailureResultAs<CommandC>();
                var failureD = ex.GetFailureResultAs<CommandD>();

                return 2;
            }
            catch (ReturnCodeException ex)
            {
                Console.Error.WriteLine(ex);

                return ex.ReturnCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);

                return ReturnCodeException.MaximumReturnCode;
            }
        }

        /// <summary>
        /// Runs the program using the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        private static void Run(Arguments arguments)
        {
            var assemblyDetails = new AssemblyDetails();

            ConsoleHelper.DisplayHeader(assemblyDetails);
            ConsoleHelper.Display();

            // TODO: Functionality here
        }
    }
}
