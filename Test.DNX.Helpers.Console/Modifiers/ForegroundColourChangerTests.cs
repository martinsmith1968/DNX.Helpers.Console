using System;
using DNX.Helpers.Console.Modifiers;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Console.Modifiers
{
    [TestFixture]
    public class ConsoleColourChangerTests
    {
        [Test]
        public void ForegroundColorChanger_can_set_and_restore_previous_colour()
        {
            // Check
            if (System.Console.IsOutputRedirected)
            {
                TestRunner.TestRunnerType.ShouldBe(TestRunnerType.NUnit);

                Assert.Inconclusive("Test needs to be run by ConsoleApp Tests");
            }

            // Arrange
            var previousColour = System.Console.ForegroundColor;
            var requiredColour = ConsoleColor.DarkCyan;

            // Act
            using (var changer = new ForegroundColourChanger(requiredColour))
            {
                changer.PreviousColour.ShouldBe(previousColour);

                System.Console.ForegroundColor.ShouldBe(requiredColour);
            }

            // Assert
            System.Console.ForegroundColor.ShouldBe(previousColour);
        }

        [Test]
        public void ForegroundColorChanger_can_set_and_change_colour_and_still_restore_previous_colour()
        {
            // Check
            if (System.Console.IsOutputRedirected)
            {
                TestRunner.TestRunnerType.ShouldBe(TestRunnerType.NUnit);

                Assert.Inconclusive("Test needs to be run by ConsoleApp Tests");
            }

            // Arrange
            var previousColour = System.Console.ForegroundColor;
            var requiredColour = ConsoleColor.DarkCyan;
            var changedColour = ConsoleColor.DarkMagenta;

            // Act
            using (var changer = new ForegroundColourChanger(requiredColour))
            {
                changer.PreviousColour.ShouldBe(previousColour);

                System.Console.ForegroundColor.ShouldBe(requiredColour);

                changer.ChangeColour(changedColour);
                System.Console.ForegroundColor.ShouldBe(changedColour);
            }

            // Assert
            System.Console.ForegroundColor.ShouldBe(previousColour);
        }

        [Test]
        public void ForegroundColorChanger_can_set_and_reset_and_change_colour_and_still_restore_previous_colour()
        {
            // Check
            if (System.Console.IsOutputRedirected)
            {
                TestRunner.TestRunnerType.ShouldBe(TestRunnerType.NUnit);

                Assert.Inconclusive("Test needs to be run by ConsoleApp Tests");
            }

            // Arrange
            var previousColour = System.Console.ForegroundColor;
            var requiredColour = ConsoleColor.DarkCyan;
            var changedColour = ConsoleColor.DarkMagenta;

            // Act
            using (var changer = new ForegroundColourChanger(requiredColour))
            {
                changer.PreviousColour.ShouldBe(previousColour);

                System.Console.ForegroundColor.ShouldBe(requiredColour);

                changer.Reset();
                System.Console.ForegroundColor.ShouldBe(previousColour);

                changer.ChangeColour(changedColour);
                System.Console.ForegroundColor.ShouldBe(changedColour);
            }

            // Assert
            System.Console.ForegroundColor.ShouldBe(previousColour);
        }
    }
}
