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

        public static bool IsValidEmail(string email)
        {
            return true;
        }
    }
}