namespace Framework.Core.CacheService
{
    public interface ICacheKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string DbKey { get; set; }
    }
}