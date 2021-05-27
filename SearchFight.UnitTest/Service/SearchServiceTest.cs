using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using Searchfight.Service.Services;
using Searchfight.Service.Interfaces;
using Searchfight.Service.Interfaces.SearchEngines;
using Searchfight.Core.Search;

namespace SearchFight.UnitTest.Service
{
    public class SearchServiceTest
    {
        private SearchService _searchService;
        private SearchEngineFactoryService _searchEngineFactoryService;
        private ISearchEngineGoogleService _googleService;
        private ISearchEngineBingService _bingService;

        [SetUp]
        public void Setup()
        {
            _googleService = Substitute.For<ISearchEngineGoogleService>();
            _bingService = Substitute.For<ISearchEngineBingService>();
        }

        [Test]
        public void GetSearchResult_Successfull()
        {
            var arguments = new List<string>() { "batman", "superman" };

            _googleService.SearchKeyWord("batman")
                .Returns(new SearchEngineResult { KeyWord = "batman", SearchEngineName = "Google", TotalResult = 50 });

            _googleService.SearchKeyWord("superman")
                .Returns(new SearchEngineResult { KeyWord = "superman", SearchEngineName = "Google", TotalResult = 30 });

            _bingService.SearchKeyWord("batman")
                .Returns(new SearchEngineResult { KeyWord = "batman", SearchEngineName = "Bing", TotalResult = 20 });

            _bingService.SearchKeyWord("superman")
                .Returns(new SearchEngineResult { KeyWord = "superman", SearchEngineName = "Bing", TotalResult = 10 });

            _searchEngineFactoryService = new SearchEngineFactoryService(_googleService, _bingService);
            _searchService = new SearchService(_searchEngineFactoryService);

            Assert.NotNull(_searchService.GetSearchResult(arguments));
        }
    }
}
