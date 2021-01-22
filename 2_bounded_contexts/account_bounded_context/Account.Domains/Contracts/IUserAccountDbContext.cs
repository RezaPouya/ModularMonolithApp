using Account.Domains.User.Entities;
using Framework.Core.Markers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Domains.Contracts
{
    public interface IUserAccountDbContext : IScopedDependency
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserEventEntity> UserEvents { get; set; }

    }
}
