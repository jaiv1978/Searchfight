using Searchfight.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Services
{
    public class PrintService : IPrintService
    {
        private readonly ISearchService _searchService;

        public PrintService(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task PrintSearchResult(List<string> keyWords)
        {
                var result = await _searchService.GetSearchResult(keyWords);

                Console.WriteLine("#################### SEARCHING RESULTS ####################");
                Console.WriteLine("");
                Console.WriteLine("                    RESULTS BY KEYWORDS                    ");
                Console.WriteLine("                    ===================                    ");
                Console.WriteLine("");

                foreach (var keyWord in keyWords)
                {
                    Console.WriteLine($"    Keyword:    {keyWord}");
                    var list = result.SearchEngineResults.Where(x => x.KeyWord.Equals(keyWord, StringComparison.OrdinalIgnoreCase));

                    foreach (var item in list)
                    {
                        Console.WriteLine($"        * {item.SearchEngineName}: { item.TotalResult } results ");
                    }
                    Console.WriteLine("");
                }

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                RANKING BY SEARCH ENGINES                 ");
                Console.WriteLine("                =========================                 ");
                Console.WriteLine("");

                foreach (var ranking in result.SearchRankingResults)
                {
                    Console.WriteLine($"    { ranking.WinnerSearchEngineName } winner: { ranking.KeyWord }");
                }

                Console.WriteLine("");
                Console.WriteLine("                      KEYWORD WINNER                     ");
                Console.WriteLine("                      ==============                     ");
                Console.WriteLine("");
                Console.WriteLine($"                    { result.WinnerSearchEngine }             ");
        }
    }
}
