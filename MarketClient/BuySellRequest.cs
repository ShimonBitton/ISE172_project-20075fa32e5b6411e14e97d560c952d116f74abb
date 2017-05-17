using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

        class BuySellRequest
        {
            public string type;
            public int commodity;
            public int amount;
            public int price;

        public BuySellRequest(int commodity, int price, int amount, string type)
        {
            this.commodity = commodity;
            this.price = price;
            this.amount = amount;
            this.type = type;
        }
    }
}
