using Account.Domains.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Account.App.Infrastructure.IocConfigs
{
    public static class Account_Ioc_Config
    {
        public static void Add_Account_Configs(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<UserAccountDbContext>(options =>
                    options.UseInMemoryDatabase("ExampleSolutionDb"));
            }
            else
            {
                services.AddDbContextPool<UserAccountDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
                        b => b.MigrationsAssembly(typeof(UserAccountDbContext).Assembly.FullName));
                }, poolSize: 128);

                //services.AddDbContext<UserAccountDbContext>(options =>
                //    options.UseSqlServer(
                //        configuration.GetConnectionString("DefaultConnection"),
                //        b => b.MigrationsAssembly(typeof(UserAccountDbContext).Assembly.FullName)));
            }

            services.AddScoped<IUserAccountDbContext>(provider => provider.GetService<UserAccountDbContext>());
        }
    }
}