using Account.Domains;
using Framework.Core.Singletons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection;

namespace EndPoints.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            SetSingletons();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetSingletons()
        {
            DomainEventInfoSingleton.GetInstance(_getAssemblies());
        }

        private static List<Assembly> _getAssemblies()
        {
            var assemblies = new List<Assembly>()
            {
                typeof(IAccount_Domain_Assembly_Marker).Assembly
            };

            return assemblies;
        }
    }
}