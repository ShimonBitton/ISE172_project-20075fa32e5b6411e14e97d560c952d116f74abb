using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient
{
   public class ItemQuery : IMarketItemQuery
    {
        public int price { get; set; }
        public int amount { get; set; }
        public string type { get; set; }
        public string user { get; set; }
        public int commodity { get; set; }

        public ItemQuery(int price, int amount, string type, string user, int commodity)
        {
            this.price = price;
            this.amount = amount;
            this.type = type;
            this.user = user;
            this.commodity = commodity;
        }

        public override string ToString()
        {
            string output = "Price: " + price + "\n" + "Amount: " + amount + "\n" + "Type: " + type + "\n" + "User: " + user + "\n" + "Commodity: " + commodity;
            return output;
        }

    }
}
