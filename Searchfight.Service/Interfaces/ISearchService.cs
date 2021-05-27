using Searchfight.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Interfaces
{
    public interface ISearchService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        Task<SearchResult> GetSearchResult(List<string> keyWords);
    }
}
