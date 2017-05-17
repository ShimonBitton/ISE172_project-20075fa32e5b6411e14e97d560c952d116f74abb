using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;
using MarketClient.Utils;
using MarketClient;

namespace BL
{
    public class MarketClientStock : IMarketClient
    {

        public int SendBuyRequest(int commodity, int price, int amount)
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendBuyRequest(commodity, price, amount);
        }

        public bool SendCancelBuySellRequest(int id)
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendCancelBuySellRequest(id);
        }

        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendQueryBuySellRequest(id);
        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendQueryMarketRequest(commodity);
        }

        public IMarketUserData SendQueryUserRequest()
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendQueryUserRequest();
        }

        public int SendSellRequest(int price, int commodity, int amount)
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendSellRequest(price, commodity, amount);
        }

        public AllMarketOffer[] SendQueryAllMarketRequests()
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendQueryAllMarketRequests();
        }

        public AllRequestsRequest[] SendQueryUserRequestsRequest()
        {
            MarketClient.RequestManager output = new MarketClient.RequestManager();
            return output.SendQueryUserRequestsRequest();
        }
    }
}
