using Account.Domains.User.Entities;
using Framework.Core.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Domains.User.Repositories
{
    public interface IUserRepository : IScopedDependency
    {
        Task<UserEntity> GetAllEvents(string userId, CancellationToken cancellationToken);

        Task<UserEntity> GetAllLastSnapShotEvents(string userId, CancellationToken cancellationToken);

        Task<bool> IsUserExists(string userId, CancellationToken cancellationToken);

        Task<int> SaveChangeAsync(UserDomain user, CancellationToken cancellationToken);
    }
}