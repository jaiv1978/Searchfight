using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Searchfight.Service.Interfaces;
using Searchfight.Service.Interfaces.SearchEngines;
using Searchfight.Service.Services;

namespace Searchfight.Service.IoC
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ResolveServicesDependecies(this IServiceCollection services)
        {
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<ISearchEngineFactoryService, SearchEngineFactoryService>();
            services.AddSingleton<ISearchEngineGoogleService, SearchEngineGoogleService>();
            services.AddSingleton<ISearchEngineBingService, SearchEngineBingService>();
            services.AddSingleton<IPrintService, PrintService>();

            return services;
        }
    }
}
