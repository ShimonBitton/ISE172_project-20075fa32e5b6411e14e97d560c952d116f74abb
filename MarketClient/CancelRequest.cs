using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    class CancelRequest
    {
        public string type;
        public int id;

        public CancelRequest(int id)
        {
            type = "cancelBuySell";
            this.id = id;
        }
    }
}
