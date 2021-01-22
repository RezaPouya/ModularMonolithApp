using Framework.Core.Common.Models;
using Framework.Core.Helpers;
using System;

namespace Account.Domains.User.ValueObjects
{
    public sealed record UserEmail
    {
        public UserEmail(string email = "", bool isConfirmed = false, DateTimeOffset? confimationTime = null)
        {
            Email = email;
            IsConfirmed = isConfirmed;
            ConfimationTime = confimationTime;
        }

        public string Email { get; private set; }
        public bool IsConfirmed { get; private set; }
        public DateTimeOffset? ConfimationTime { get; private set; }
        public string ConfirmationCode { get; private set; }
        public DateTimeOffset? ConfirmationCodeExpirationTime { get; private set; }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// </summary>
        public static ValidationModel IsEmailValid(string email)
        {
            var validation = new ValidationModel();

            if (email.IsValidEmail())
                validation.AddValidationError("ایمیل وارد شده معتبر نیست");

            return validation;
        }
    }
}