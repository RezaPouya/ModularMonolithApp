using Framework.Core.Common.Models;
using Framework.Core.Markers;
using System;

namespace Account.Domains.User.ValueObjects
{
    public record UserEmailConfirmation : IValueObject 
    {

        public UserEmailConfirmation(string confirmationCode,
            DateTimeOffset confirmationCodeExpirationTime)
        {
            ConfirmationCode = confirmationCode;
            ConfirmationCodeExpirationTime = confirmationCodeExpirationTime;
        }

        public string ConfirmationCode { get; private set; }
        public DateTimeOffset ConfirmationCodeExpirationTime { get; private set; }

        public  ValidationModel IsValid(string confiramtionCode)
        {
            var validation = new ValidationModel();

            if (confiramtionCode != this.ConfirmationCode )
                validation.AddValidationError("کد وارد شده معتبر نیست");

            if(DateTimeOffset.UtcNow > this.ConfirmationCodeExpirationTime.UtcDateTime)
                validation.AddValidationError("کد وارد شده ، منقضی شده است ، لطفا دوباره درخواست دهید");

            return validation;
        }
    }

}