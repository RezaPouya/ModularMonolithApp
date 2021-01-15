using System;

namespace Framework.Core.CacheService
{
    public interface ICacheItem<T> : ICacheKey
    {
        public T Data { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}