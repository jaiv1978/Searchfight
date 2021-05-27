using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;

using Searchfight.Service.IoC;
using Searchfight.App.IoC;
using Searchfight.Service.Interfaces;
using Microsoft.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace Searchfight.App
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine(" Starting SEARCHFIGHT");
            Console.WriteLine("");

            try
            {
                MainAsync(args).Wait();
            }
            catch(Exception ex)
            {
                Console.WriteLine($" An exception has occurred:  {ex.Message}");
            }
        }

        static async Task MainAsync(string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "Searchfight",
                FullName = "Searchfight App",
                Description = "Search keywords using search engines and ranking the results"
            };

            var serviceProvider = new ServiceCollection()
                .ResolveServicesDependecies()
                .ResolveAppDependecies()
                .BuildServiceProvider();

            var keyWordsArg = app.Argument("[keywords]", "A list of keywords to be search", true);

            app.OnExecute(async ()  =>
            {
                Console.WriteLine(" The application is running, we are searching your keywords, this could take a few seconds...");
                Console.WriteLine("");
                Console.WriteLine("");

                var printService = serviceProvider.GetService<IPrintService>();
                await printService.PrintSearchResult(keyWordsArg.Values);
                return 0;
            });

            try
            {
                app.Execute(args);
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
