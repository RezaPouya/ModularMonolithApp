using System.Threading.Tasks;

namespace Framework.Core.CacheService
{
    public interface ICacheService
    {
        public Task<T> Get<T>(ICacheKey objKey);

        public Task<(bool exist, T data)> TryGetValue<T>(ICacheKey objKey);

        public Task Add<T>(ICacheItem<T> obj);

        public Task Delete(ICacheKey objKey);
    }
}