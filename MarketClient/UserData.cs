using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient
{
   public class UserData : IMarketUserData
    {
        public double funds { get; set; }
        public Dictionary<string, int> commodities { get; set; }
        public List<int> requests { get; set; }

        public UserData(double funds, Dictionary<string, int> commodities, List<int> requests)
        {
            this.funds = funds;
            this.commodities = commodities;
            this.requests = requests;
        }
        public override string ToString()
        {
            String output = "";
            output = "Commodities(Key:Value): " + stringDictionary() + "\n" + "Funds: " + funds + "\n" + "Requests: " + stringList();
            return output;
        }
        private string stringDictionary() //strings "commodities" dictionary
        {
            string output = "";
            foreach (KeyValuePair<String, int> line in commodities)
            {
                output = output + line.Key + ":" + line.Value + " ";
            }
            return output;
        }
        private string stringList() //strings "requests" list
        {
            string output = "";
            foreach (int line in requests)
            {
                output = output + line + " ";
            }
            return output;
        }
    }
}
