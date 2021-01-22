using Framework.Core.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Account.Domains.User.Contracts
{
    public interface IUserDomainService : IScopedDependency
    {
        Task<UserDomain> GetUser(string userId, CancellationToken cancellationToken, bool takeFromLastSnapshot = false);
    }
}
