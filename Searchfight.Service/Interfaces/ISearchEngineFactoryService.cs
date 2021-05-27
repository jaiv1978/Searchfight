using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Interfaces
{
    public interface ISearchEngineFactoryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ISearchEngineService> GetSearchEngines();

    }
}
