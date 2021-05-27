using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.App.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ResolveAppDependecies(this IServiceCollection services)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                    .AddJsonFile("appsettings.json", false)
                    .Build();

            services.AddSingleton<IConfiguration>(configuration);

            return services;
        }
    }
}
