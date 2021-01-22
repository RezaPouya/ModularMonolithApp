using Account.Domains.Contracts;
using Account.Domains.User.Repositories;

namespace Account.App.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserAccountDbContext _dbContext;

        public UserRepository(IUserAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}