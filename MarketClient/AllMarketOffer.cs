using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
    public class AllMarketOffer
    {
        public CommodityOffer offer;
        public int id;

        override
        public string ToString()
        {
            string output= "id: " + id+ "\n"+ offer ;
            return output;
        }
    }
}
