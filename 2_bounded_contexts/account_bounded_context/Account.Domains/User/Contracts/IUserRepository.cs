using Account.Domains.User.Entities;
using Framework.Core.Common.Contracts;

namespace Account.Domains.User.Repositories
{
    public interface IUserRepository : IAbstractDomainRepository<UserDomain>
    {
    }
}