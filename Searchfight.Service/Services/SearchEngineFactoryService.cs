using Searchfight.Service.Interfaces;
using Searchfight.Service.Interfaces.SearchEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Services
{
    public class SearchEngineFactoryService : ISearchEngineFactoryService
    {
        private readonly ISearchEngineGoogleService _googleService;
        private readonly ISearchEngineBingService _bingService;

        public SearchEngineFactoryService(ISearchEngineGoogleService googleService,
                                            ISearchEngineBingService bingService)
        {
            _googleService = googleService;
            _bingService = bingService;
        }

        public List<ISearchEngineService> GetSearchEngines()
        {
            return new List<ISearchEngineService>() {
                _googleService,
                _bingService
            };
        }
    }
}
