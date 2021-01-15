using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace("ي", "ی")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }

        public static string CleanString(this string str)
        {
            return str.Trim().FixPersianChars().Fa2En().NullIfEmpty();
        }

        public static string NullIfEmpty(this string str)
        {
            return str?.Length == 0 ? null : str;
        }

        public static string CommaSeparateDigit(this int s)
        {
            return $"{s:#,##0}";
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns>something like this : (223),(234234),(223),(234234)</returns>
        public static string GenerateStringListForSqlParameter(this List<int> list)
        {
            var result = new StringBuilder();
            var length = list.Count();
            var count = 1;
            list.ForEach(p =>
            {
                result.Append($"({p}){(count < length ? ',' : ' ')}");
                count++;
            });
            return result.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns>something like this : (223),(234234),(223),(234234)</returns>
        public static string GenerateStringListForSqlParameter(this List<short> list)
        {
            var result = new StringBuilder();
            var length = list.Count();
            var count = 1;
            list.ForEach(p =>
            {
                result.Append($"({p}){(count < length ? ',' : ' ')}");
                count++;
            });
            return result.ToString();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        /// <returns>(223),(234234),(223),(234234)</returns>
        public static string GenerateStringListForSqlParameter(this List<string> list)
        {
            var result = new StringBuilder();
            var length = list.Count();
            var count = 1;
            list.ForEach(p =>
            {
                result.Append($"(N'{p}'){(count < length ? ',' : ' ')}");
                count++;
            });
            return result.ToString();
        }

        public static string ContactWithPersianAnd(this List<string> list, bool addPersianQutation = false)
        {
            var result = new StringBuilder();
            var length = list.Count();
            var count = 1;
            list.ForEach(p =>
            {
                if (addPersianQutation)
                {
                    result.Append($" « {p} » ");
                }
                else
                {
                    result.Append($"{p}");
                }

                if (count < length)
                {
                    result.Append($" و ");
                }

                count++;
            });
            return result.ToString();
        }
    }
}