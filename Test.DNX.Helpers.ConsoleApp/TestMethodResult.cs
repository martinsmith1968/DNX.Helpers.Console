using System;
using System.Reflection;
using DNX.Helpers.Exceptions;

namespace Test.DNX.Helpers.ConsoleApp
{
    public enum ResultType
    {
        Succeeded,
        Failed,
        Ignored,
    }

    public class TestMethodResult
    {
        public MethodInfo Method { get; private set; }

        public ResultType ResultType { get; private set; }

        public string Message { get; private set; }

        private TestMethodResult(MethodInfo method, ResultType resultType, string message)
        {
            Method     = method;
            ResultType = resultType;
            Message    = message;
        }

        public static TestMethodResult Success(MethodInfo method)
        {
            return new TestMethodResult(method, ResultType.Succeeded, null);
        }

        public static TestMethodResult Failure(MethodInfo method, string message)
        {
            return new TestMethodResult(method, ResultType.Failed, message);
        }

        public static TestMethodResult Failure(MethodInfo method, Exception ex)
        {
            var messages = ex.GetMessageList();

            return TestMethodResult.Failure(method, string.Join(Environment.NewLine, messages));
        }
    }
}
