using System;
using DNX.Helpers.Console;

namespace SampleConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start");
            using (var changer = new ConsoleColourChanger(ConsoleColor.Green))
            {
                Console.WriteLine("{0} on {1}", Console.ForegroundColor, Console.BackgroundColor);

                changer.SetForeground(ConsoleColor.Yellow);
                Console.WriteLine("{0} on {1}", Console.ForegroundColor, Console.BackgroundColor);

                changer.SetBackground(ConsoleColor.Gray);
                changer.SetBackground(ConsoleColor.Red);
                Console.WriteLine("{0} on {1}", Console.ForegroundColor, Console.BackgroundColor);
            }
            Console.WriteLine("Finish");

            while (Console.KeyAvailable)
                Console.ReadKey(true);
            Console.ReadKey();
        }
    }
}
