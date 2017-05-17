using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    class QueryMarketRequest
    {
        public string type;
        public int commodity;

        public QueryMarketRequest(int commodity)
        {
            type = "queryMarket";
            this.commodity = commodity;
        }
    }
}
