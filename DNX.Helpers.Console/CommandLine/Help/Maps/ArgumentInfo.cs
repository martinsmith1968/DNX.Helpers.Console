using System.Linq;
using System.Reflection;
using CommandLine;
using DNX.Helpers.Linq;

namespace DNX.Helpers.Console.CommandLine.Help.Maps
{
#pragma warning disable 1591
    public static class ArgumentInfo
    {
        public static bool IsPositionalArgument(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes<ValueAttribute>()
                .HasAny();
        }

        public static PositionalArgumentInfo GetPositionalArgumentInfo(MemberInfo memberInfo)
        {
            var attributes = memberInfo.GetCustomAttributes<ValueAttribute>(true)
                .ToList();

            return PositionalArgumentInfo.Create(memberInfo, attributes.FirstOrDefault());
        }

        public static bool IsOptionArgument(MemberInfo memberInfo)
        {
            return memberInfo.GetCustomAttributes<OptionAttribute>()
                .HasAny();
        }

        public static OptionArgumentInfo GetOptionArgumentInfo(MemberInfo memberInfo)
        {
            var attributes = memberInfo.GetCustomAttributes<OptionAttribute>(true)
                .ToList();

            return OptionArgumentInfo.Create(memberInfo, attributes.FirstOrDefault());
        }
    }
}
