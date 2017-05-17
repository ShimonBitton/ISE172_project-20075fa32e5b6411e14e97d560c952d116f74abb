using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    class QueryBuySellRequest
    {
        public string type;
        public int id;

        public QueryBuySellRequest(int id)
        {
            type = "queryBuySell";
            this.id = id;
        }
    }
}
