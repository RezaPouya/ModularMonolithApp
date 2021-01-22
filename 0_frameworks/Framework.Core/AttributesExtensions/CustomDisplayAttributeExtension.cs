using Framework.Core.Attributes;
using Framework.Core.Helpers;
using System;
using System.Reflection;

namespace Framework.Core.AttributesExtensions
{
    public static class CustomDisplayAttributeExtension
    {
        public static string GetDisplayNameFa(this Enum @enum)
        {
            MemberInfo[] memInfo = (@enum.GetType()).GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attr = memInfo[0].GetCustomAttribute(typeof(CustomDisplayAttribute), false);

                if (attr is null)
                    throw new NullReferenceException($"The custome attribute is not set for '{@enum}'");

                if (attr is CustomDisplayAttribute)
                    return ((CustomDisplayAttribute)attr)?.Title ?? "";
            }

            return @enum.ToString();
        }

        public static string GetDisplayNameEn(this Enum @enum)
        {
            MemberInfo[] memInfo = (@enum.GetType()).GetMember(@enum.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attr = memInfo[0].GetCustomAttribute(typeof(CustomDisplayAttribute), false);

                if (attr is null)
                    throw new NullReferenceException($"The custome attribute is not set for '{@enum}'");

                if (attr is CustomDisplayAttribute)
                    return ((CustomDisplayAttribute)attr)?.TitleEn ?? "";
            }

            return @enum.ToString();
        }
    }
}