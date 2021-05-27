using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using Searchfight.Core.Common;
using Searchfight.Core.Search;
using Searchfight.Service.Interfaces.SearchEngines;

namespace Searchfight.Service.Services
{
    public class SearchEngineBingService : ISearchEngineBingService
    {
        private readonly IConfiguration _configuration;

        public SearchEngineBingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SearchEngineName => AppConstants.BingEngine;

        public async Task<SearchEngineResult> SearchKeyWord(string keyWord)
        {
            var output = new SearchEngineResult() { SearchEngineName = AppConstants.BingEngine, KeyWord = keyWord, TotalResult = 0 };
            var customConfigId = _configuration.GetValue<string>("SearchSettings:BingCustomConfigId");
            var suscriptionKey = _configuration.GetValue<string>("SearchSettings:BingSuscriptionKey");

            try
            {
                var uriQuery = string.Format(AppConstants.BingSearchUrlAPI, Uri.EscapeDataString(keyWord), Uri.EscapeDataString(customConfigId));
                var request = HttpWebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = suscriptionKey;

                var response = await request.GetResponseAsync();
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                dynamic jsonObj = JsonConvert.DeserializeObject(json);
                 
                var totalResults = (string) jsonObj.webPages.totalEstimatedMatches;
                output.TotalResult = long.Parse(totalResults);
            }
            catch(Exception ex)
            {
                throw;
            }

            return output;
        }
    }
}
