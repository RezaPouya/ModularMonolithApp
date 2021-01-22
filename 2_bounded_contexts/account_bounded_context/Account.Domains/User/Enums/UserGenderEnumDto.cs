using Framework.Core.AttributesExtensions;
using Framework.Core.BaseModels;
using Framework.Core.Exceptions;
using Framework.Core.Extensions;
using System;

namespace Account.Domains.User.Enums
{
    public sealed record UserGenderEnumDto : IdTitileDto<UserGenderEnum>
    {
        public UserGenderEnumDto(UserGenderEnum id)
        {
            if (Enum.IsDefined(typeof(UserGenderEnum), id) == false)
            {
                throw new EnumValidationException($"the value of '{id}' is not valid value for {nameof(UserGenderEnum)}");
            }

            Id = id;
            Title = id.GetDisplayNameFa();
            TitleEn = id.GetDisplayNameEn();
        }
    }
}