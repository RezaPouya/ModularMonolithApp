
using Account.Domains.User.Exceptions;
using Framework.Core.Common.Contracts;
using Framework.Core.Common.Models;
using Framework.Core.Helpers;
using Framework.Core.Markers;
using System;

namespace Account.Domains.User.ValueObjects
{
    public record UserAccountInfo : IValueObject
    {
        public UserAccountInfo(string userName, string passwordHash, DateTimeOffset lastUpdate)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            LastUpdate = lastUpdate;
        }

        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTimeOffset LastUpdate { get; private set; }

        #region static validation

        public static ValidationModel IsUserNameValid(string userName)
        {
            var validation = new ValidationModel();

            if (userName.Length < 6)
                validation.AddValidationError("نام کاربری حداقل باید 6 کاراکتر داشته باشد");

            return validation;
        }

        public static ValidationModel IsPasswordValid(string password)
        {
            var validation = new ValidationModel();

            if (password.Length <= 8)
                validation.AddValidationError("کلمه عبور باید حداقل 8 کاراکتر باشد ");

            return validation;
        }

        #endregion static validation

        public ValidationModel IsNewPasswordValid(string password)
        {
            var validation = IsPasswordValid(password);

            if (validation.IsValid == false)
                throw new UserValidationException(validation.GetValidationErrorMessages());

            var generatedPasswordHash = GeneratePasswordHash(password);

            if (this.PasswordHash.Equals(generatedPasswordHash))
                validation.AddValidationError("کلمه ی عبور فعلی با کلمه ی عبور قبلی شما برابر است");

            return validation;
        }

        public static string GeneratePasswordHash(string password)
        {
            return SecurityHelper.GetSha256Hash(password);
        }
    }
}