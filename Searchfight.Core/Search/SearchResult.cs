using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Core.Search
{
    public class SearchResult
    {
        public List<SearchEngineResult> SearchEngineResults { get; set; } = new List<SearchEngineResult>();

        public List<SearchRankingResult> SearchRankingResults { get; set; } = new List<SearchRankingResult>();

        public string WinnerSearchEngine { get; set; }
    }
}
