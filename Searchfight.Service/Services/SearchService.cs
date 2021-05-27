using Searchfight.Core.Search;
using Searchfight.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Services
{
    public class SearchService : ISearchService
    {
        private readonly ISearchEngineFactoryService _searchEngineFactoryService;

        public SearchService(ISearchEngineFactoryService searchEngineFactoryService)
        {
            _searchEngineFactoryService = searchEngineFactoryService;
        }

        public async Task<SearchResult> GetSearchResult(List<string> keyWords)
        {
            if (!keyWords.Any())
                throw new ArgumentException("There are no keywords for searching", nameof(keyWords));

            var output = new SearchResult();
            var searchEngines = _searchEngineFactoryService.GetSearchEngines();
            
            foreach(var keyWord in keyWords)
            {
                foreach (var searchEngine in searchEngines)
                {
                    var result = await searchEngine.SearchKeyWord(keyWord);
                    output.SearchEngineResults.Add(result);
                }
            }

            foreach (var searchEngine in searchEngines)
            {
                var filtered = output.SearchEngineResults
                       .Where(s => s.SearchEngineName.Equals(searchEngine.SearchEngineName, StringComparison.OrdinalIgnoreCase));

                var max = filtered.FirstOrDefault(f => f.TotalResult == filtered.Max(x => x.TotalResult));

               if (max != null)
                    output.SearchRankingResults.Add(new SearchRankingResult { KeyWord = max.KeyWord, WinnerSearchEngineName = searchEngine.SearchEngineName });
            }

            var winner = output.SearchEngineResults.GroupBy(s => s.KeyWord)
                            .Select(x => new { keyWords = x.Key, total = x.Sum(c => c.TotalResult) })
                            .OrderByDescending(x => x.total)
                            .FirstOrDefault();

            output.WinnerSearchEngine = winner?.keyWords ?? "";

            return output;
        }
    }
}
