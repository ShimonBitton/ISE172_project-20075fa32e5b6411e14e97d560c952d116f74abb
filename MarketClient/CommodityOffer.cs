using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient
{
    public class CommodityOffer : IMarketCommodityOffer
    {
        public int ask;
        public int bid;

        public override string ToString()
        {
            string output = "Ask Price: " + ask + "\n" + "Bid Price: " + bid;
            return output;
        }
    }
}
