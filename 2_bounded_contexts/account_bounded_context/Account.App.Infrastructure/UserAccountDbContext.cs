using Account.Domains.Contracts;
using Account.Domains.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Account.App.Infrastructure
{
    public class UserAccountDbContext : DbContext, IUserAccountDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserEventDbEntity> UserEvents { get; set; }
    }
}