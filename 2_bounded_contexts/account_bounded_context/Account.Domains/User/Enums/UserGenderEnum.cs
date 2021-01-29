using Framework.Core.Attributes;

namespace Account.Domains.User.Enums
{
    public enum UserGenderEnum : byte
    {
        [EnumDisplay(name: "مشخص نشده", nameEn: "not specified", displayOrder: 0)]
        NotSpecified = 0,

        [EnumDisplay(name: "مرد", nameEn: "Male", displayOrder: 1)]
        Male = 1,

        [EnumDisplay(name: "زن", nameEn: "Female", displayOrder: 2)]
        Female = 2,
    }
}