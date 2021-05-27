using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Service.Interfaces
{
    public interface IPrintService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyWords"></param>
        /// <returns></returns>
        Task PrintSearchResult(List<string> keyWords);
    }
}
