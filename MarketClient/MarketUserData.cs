using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;

namespace MarketClient 
{
    class MarketUserData : IMarketUserData
    {
        public float funds;
        public Dictionary<string, int> commodities;//Dictionary is a proper data structure to use the needed data.
        public List<int> requests;

        public MarketUserData(float funds, Dictionary<string, int> commodities, List<int> requests)
        {
            this.funds = funds;
            this.commodities = commodities;
            this.requests = requests;
        }
        public override string ToString()
        {

            return "Funds: " + funds.ToString() + "\n" + "Commodities: " + StringDictionary() + "\n" + "Requests: " + StringList();
        }
        private string StringDictionary()//Private method to string a dictionary in an appropriate way for the user.
        {
            string s = "";
            foreach (KeyValuePair<string, int> i in commodities)
                s = s + i.Key + ": " + i.Value + " ";
            return s;
        }
        private string StringList()//Private method to string a list in an appropriate way for the user.
        {
            string s = "";
            foreach (int i in requests)
                s = s + i + " ";
            return s;
        }


    }
}
