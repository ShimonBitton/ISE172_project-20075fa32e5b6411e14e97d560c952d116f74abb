using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class QueryUserRequestsRequest
    {
        public string type;

        public QueryUserRequestsRequest()
        {
            type = "queryUserRequests";
        }
    }
}
