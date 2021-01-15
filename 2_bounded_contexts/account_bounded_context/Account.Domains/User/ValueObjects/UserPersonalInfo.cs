using Account.Domains.User.Enums;
using System;

namespace Account.Domains.User.ValueObjects
{
    public sealed record UserPersonalInfo
    {
        public UserPersonalInfo(string fname = "",
            string lname = "",
            DateTimeOffset? birthDay = null,
            UserGenderEnum gender = UserGenderEnum.NotSpecified)
        {
            Fname = fname;
            Lname = lname;
            BirthDay = birthDay;
            Gender = gender;
        }

        public string Fname { get; private set; }
        public string Lname { get; private set; }
        public DateTimeOffset? BirthDay { get; private set; }
        public UserGenderEnum Gender { get; private set; }
        public string FullName => $"{Fname} {Lname}".Trim();

        public bool IsValidBirthDay(DateTimeOffset? birthDay)
        {
            return true;
        }
    }
}