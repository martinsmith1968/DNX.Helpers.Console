namespace Test.DNX.Helpers.Console
{
    public enum TestRunnerType
    {
        NUnit,
        Console
    }

    public static class TestRunner
    {
        public static TestRunnerType TestRunnerType { get; set; }

        static TestRunner()
        {
            TestRunnerType = TestRunnerType.NUnit;
        }
    }
}
