using Account.Domains.Common;
using Account.Domains.Common.Behaviours;
using Account.Domains.Common.Contracts;
using Account.Domains.User.Events;
using Account.Domains.User.Exceptions;
using Account.Domains.User.ValueObjects;
using System;

namespace Account.Domains.User
{
    public partial class User : AggregateRoot<string>
    {
        public User(string idenity) : base(idenity)
        {
        }

        private const string _aggregateName = AggregatesConstatnts.User;

        public override string GenerateIdentity() => $"{_aggregateName}-{DateTimeOffset.Now.Ticks}-{Guid.NewGuid().ToString("x")}";

        public UserAccountInfo AccountInfo { get; set; }
        public UserPersonalInfo PersonalInfo { get; private set; }
        public UserEmail Email { get; private set; }
        public UserCellphone Cellphone { get; private set; }

        #region behaviour

        public bool SetUserNameAndPassword(string userName, string password)
        {
            UserAccountInfo.IsUserNameValid(userName).Validate<UserAccountValidationException>();
            UserAccountInfo.IsPasswordValid(password).Validate<UserAccountValidationException>();

            // create event
            var @event = new UserUnameIsSetEvent(this.Identity,
                DateTimeOffset.UtcNow,
                userName,
                password);

            // raise event
            Apply(@event);

            return true;
        }

        public override bool SaveChange()
        {
            throw new NotImplementedException();
        }

        #endregion behaviour
    }
}