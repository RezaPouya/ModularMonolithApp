using Account.Domains.User.Entities;
using Framework.Core.Markers;
using Microsoft.EntityFrameworkCore;

namespace Account.Domains.Contracts
{
    public interface IUserAccountDbContext : IScopedDependency
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserEventDbEntity> UserEvents { get; set; }
    }
}