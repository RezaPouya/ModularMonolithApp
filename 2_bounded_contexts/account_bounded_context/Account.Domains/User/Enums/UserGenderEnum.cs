using Framework.Core.Attributes;

namespace Account.Domains.User.Enums
{
    public enum UserGenderEnum : byte
    {
        [CustomDisplay(name: "مشخص نشده", nameEn: "not specified", displayOrder: 0)]
        NotSpecified = 0,

        [CustomDisplay(name: "مرد", nameEn: "Male", displayOrder: 1)]
        Male = 1,

        [CustomDisplay(name: "زن", nameEn: "Female", displayOrder: 2)]
        Female = 2,
    }
}