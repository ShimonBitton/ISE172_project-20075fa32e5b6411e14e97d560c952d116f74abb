using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketClient
{
   public class AllRequestsRequest
    {
        public ItemQuery item;
        public int id;

        override
        public string ToString()
        {
            string output = "id: " + id + "\n" + item;
            return output;
        }
    }
}
