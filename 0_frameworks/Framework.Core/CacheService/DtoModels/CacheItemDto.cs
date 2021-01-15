using Framework.Core.CacheService.DtoModels;
using System;

namespace Framework.Core.CacheService.DtoModels
{
    public class CacheItemDto<T> : CacheKeyDto, ICacheItem<T>
    {
        public T Data { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}