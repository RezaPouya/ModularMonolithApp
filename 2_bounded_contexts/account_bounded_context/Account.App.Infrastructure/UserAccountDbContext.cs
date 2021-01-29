using Account.Domains.Contracts;
using Account.Domains.User.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.App.Infrastructure
{
    public class UserAccountDbContext : DbContext, IUserAccountDbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserEventEntity> UserEvents { get; set; }
    }
}
