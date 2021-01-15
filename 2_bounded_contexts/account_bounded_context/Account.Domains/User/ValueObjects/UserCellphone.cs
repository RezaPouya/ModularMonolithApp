using System;

namespace Account.Domains.User.ValueObjects
{
    public sealed record UserCellphone
    {
        public UserCellphone(string cellphone = "", bool isConfirmed = false, DateTimeOffset? confimationTime = null)
        {
            Cellphone = cellphone;
            IsConfirmed = isConfirmed;
            ConfimationTime = confimationTime;
        }

        public string Cellphone { get; private set; }
        public bool IsConfirmed { get; private set; }
        public DateTimeOffset? ConfimationTime { get; private set; }

        public static bool IsValidCellphoneNumber(string cellphone)
        {
            return true;
        }
    }
}