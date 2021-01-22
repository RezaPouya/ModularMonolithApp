using Account.Domains.User;
using Account.Domains.User.Contracts;
using Account.Domains.User.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Domains.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;

        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User.UserDomain> GetUser(string userId, CancellationToken cancellationToken, bool takeFromLastSnapshot)
        {
            var @events = await _repository.GetAllLastSnapShotEvents(userId, cancellationToken).ConfigureAwait(false);
            var record = new UserDomain(@events);
        }
    }
}