using Framework.Core.Markers;

namespace Framework.Core.Common.Contracts
{
    public interface ICurrentUserInfo : IScopedDependency
    {
        public string GetUserId();
        public string GetUserIp();

        public string GetUserDevice();
    }
}