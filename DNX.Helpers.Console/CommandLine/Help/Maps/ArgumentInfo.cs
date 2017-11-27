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
            if (memberInfo == null)
            {
                return false;
            }

            var attributes = memberInfo.GetCustomAttributes<ValueAttribute>(true)
                .ToList();

            return attributes.HasAny();
        }

        public static PositionalArgumentInfo GetPositionalArgumentInfo(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                return null;
            }

            var attributes = memberInfo.GetCustomAttributes<ValueAttribute>(true)
                .ToList();

            return attributes.HasAny()
                ? PositionalArgumentInfo.Create(memberInfo, attributes.First())
                : null;
        }

        public static bool IsOptionArgument(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                return false;
            }

            var attributes = memberInfo.GetCustomAttributes<OptionAttribute>(true)
                .ToList();

            return attributes.HasAny();
        }

        public static OptionArgumentInfo GetOptionArgumentInfo(MemberInfo memberInfo)
        {
            if (memberInfo == null)
            {
                return null;
            }

            var attributes = memberInfo.GetCustomAttributes<OptionAttribute>(true)
                .ToList();

            return attributes.HasAny()
                ? OptionArgumentInfo.Create(memberInfo, attributes.First())
                : null;
        }
    }
}
