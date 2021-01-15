using Framework.Core.CacheService;

namespace Framework.Core.CacheService.DtoModels
{
    public class CacheKeyDto : ICacheKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string DbKey { get; set; }
    }
}