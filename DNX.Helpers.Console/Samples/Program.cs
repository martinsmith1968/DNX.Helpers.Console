using System;
using CommandLine;
using DNX.CommandLine.Helpers.Exceptions;
using DNX.Helpers.Assemblies;
using DNX.Helpers.Console;
using DNX.Helpers.Console.CommandLine;

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
                var result = Parser.Default.Parse<Arguments>(args)
                    .WithParsed(Run);

                //var result = Parser.Default.Parse<CommandA, CommandB, CommandC, CommandD>(
                //    args,
                //    )
                //    .WithParsed<CommandA>(a => RunA(a))
                //    .WithParsed<CommandB>(a => RunB(a))
                //    .WithParsed<CommandC>(a => RunC(a))
                //    .WithParsed<CommandD>(a => RunD(a))
                //    ;

                return result.Ok()
                    ? 0
                    : 1;
            }
            catch (ReturnCodeException ex)
            {
                Console.WriteLine(ex);

                return ex.ReturnCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return int.MaxValue;
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
