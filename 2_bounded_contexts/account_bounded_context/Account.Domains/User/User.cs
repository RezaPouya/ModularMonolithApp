using Account.Domains.User.Events;
using Account.Domains.User.Exceptions;
using Account.Domains.User.ValueObjects;
using Framework.Core.Common.Models;
using Framework.Core.Extensions;
using Framework.Core.Helpers;
using System;

namespace Account.Domains.User
{
    public partial class UserDomain : AggregateRoot
    {
        public UserDomain(string idenity,
            string userName,
            string password,
            string email) : base(idenity)
        {
            idenity.IsNotNotOrEmpty<UserValidationException>(errorMessage: "Please supply id");
            UserAccountInfo.IsUserNameValid(userName).Validate<UserAccountValidationException>();
            UserAccountInfo.IsPasswordValid(password).Validate<UserAccountValidationException>();
            UserEmail.IsEmailValid(email.NormalizeEmail()).Validate<UserAccountValidationException>();

            var @event = new UserCreatedEvent(idenity,
                userName,
                UserAccountInfo.GeneratePasswordHash(password),
                email.NormalizeEmail(),
                DateTimeOffset.UtcNow);

            Apply(@event);
        }

        public UserAccountInfo AccountInfo { get; set; }
        public UserPersonalInfo PersonalInfo { get; private set; }
        public UserEmail Email { get; private set; }
        public UserEmailConfirmation UserEmailConfirmation { get; private set; }

        #region behaviour

        public bool ChangeUserName(string userName)
        {
            UserAccountInfo.IsUserNameValid(userName).Validate<UserAccountValidationException>();
            //UserAccountInfo.IsPasswordValid(password).Validate<UserAccountValidationException>();

            // create event
            var @event = new UserNameIsChangedEvent(this.Identity,
                DateTimeOffset.UtcNow,
                userName);

            // raise event
            Apply(@event);

            return true;
        }

        #endregion behaviour
    }
}