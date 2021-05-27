using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using Google.Apis.Customsearch.v1;
using Google.Apis.Services;

using Searchfight.Core.Search;
using Searchfight.Core.Common;
using Searchfight.Service.Interfaces.SearchEngines;


namespace Searchfight.Service.Services
{
    public class SearchEngineGoogleService : ISearchEngineGoogleService
    {
        private readonly IConfiguration _configuration;

        public SearchEngineGoogleService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SearchEngineName => AppConstants.GoogleEngine;

        public async Task<SearchEngineResult> SearchKeyWord(string keyWord)
        {
            var apiKey = _configuration.GetValue<string>("SearchSettings:GoogleAPIKey");
            var searEngineId = _configuration.GetValue<string>("SearchSettings:GoogleCustomSearchId");

            var searchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });
            var resultList = searchService.Cse.List();
            resultList.Cx = searEngineId;
            resultList.Q = keyWord;

            try
            {
                var result = await resultList.ExecuteAsync();
                return new SearchEngineResult { SearchEngineName = AppConstants.GoogleEngine, KeyWord = keyWord, TotalResult = long.Parse(result.SearchInformation.TotalResults) };
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
