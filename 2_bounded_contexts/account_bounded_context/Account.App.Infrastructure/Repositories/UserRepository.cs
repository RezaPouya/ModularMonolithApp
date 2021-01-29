using Account.Domains.User;
using Account.Domains.User.Entities;
using Account.Domains.User.Repositories;
using Framework.Core.Common.Contracts;

namespace Account.App.Infrastructure.Repositories
{
    public class UserRepository : AbstractDomainRepository<UserDomain, UserEventEntity>, IUserRepository
    {
        public UserRepository(UserAccountDbContext dbContext,
            ICurrentUserInfo currentUserInfo) : base(dbContext, currentUserInfo)
        {
        }
    }
}