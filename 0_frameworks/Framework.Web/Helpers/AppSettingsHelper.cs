using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace gFramework.Web.Helpers
{
    public static class AppSettingsHelper
    {
        public static T GetConfig<T>(string rootPath, string child, T defualtValue = default)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();

            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            
            try
            {
                var root = builder.Build();
                var res = root.GetSection(rootPath)
                    .GetChildren()
                    .FirstOrDefault(x => x.Key == child)
                    .Value;

                if (res != null)
                    return (T)Convert.ChangeType(res, typeof(T));

                return defualtValue;
            }
            catch (Exception)
            {
                return defualtValue;
            }
        }
    }
}