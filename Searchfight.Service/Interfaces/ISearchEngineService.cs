using Searchfight.Core.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Interfaces
{
    public interface ISearchEngineService
    {
        /// <summary>
        /// 
        /// </summary>
        string SearchEngineName { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        Task<SearchEngineResult> SearchKeyWord(string keyWord);
    }
}
