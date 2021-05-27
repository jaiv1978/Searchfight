using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Core.Search
{
    public class SearchEngineResult
    {
        public string SearchEngineName { get; set; }

        public string KeyWord { get; set; }

        public long TotalResult { get; set; }
    }
}
