using Account.Domains.Contracts;
using Account.Domains.User.Entities;
using Account.Domains.User.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Account.App.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserAccountDbContext _dbContext;

        public UserRepository(IUserAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(User user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserEntity> GetUser(string userId, CancellationToken cancellationToken)
        {
            var userRecord = await _dbContext.Users
                .Where(p => p.Id == userId)
                .Include(p => p.Events)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            if (userRecord == null)
                throw new UserValidationException("There is no record");

            return userRecord;
        }

        public async Task<UserEntity> GetUser(string userId, CancellationToken cancellationToken, bool takeFromLastSnapshot = false)
        {
            var userRecord = await _dbContext.Users
              .Where(p => p.Id == userId)
              .Include(p => p.Events.Where(p=> p.SnapShot == p.User.LastSnapShot))
              .FirstOrDefaultAsync(cancellationToken)
              .ConfigureAwait(false);

            if (userRecord == null)
                throw new UserValidationException("There is no record");

            return userRecord;
        }

        public Task<bool> IsUserExists(string userId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(UserEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(UserEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}