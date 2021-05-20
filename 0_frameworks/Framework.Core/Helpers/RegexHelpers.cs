using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Framework.Core.Helpers
{
    public static class RegexHelpers
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string NormalizeEmail(this string email)
        {
            try
            {
                email = email.ToLower().Trim();

                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return email;
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// </summary>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = email.NormalizeEmail();

                var isMatch = Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));

                return isMatch;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}