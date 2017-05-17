using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient.DataEntries;
using MarketClient.Utils;
using MarketClient;
using BL;


namespace MarketClient
{
    public class RequestManager : IMarketClient
    {
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user45";
        private const string PrivateKey =
        @"-----BEGIN RSA PRIVATE KEY-----
MIICXAIBAAKBgQCYgESP2FuQXB78meKGFKIeeJ626RuUEdFgsghe+habs0VTFqSz
LmY20zxwnIsbZdSs2WCXopZI/yQjwU2ryj9/ReMilvu2j4ZD58ag3Oc45y9MvQfc
QW7zKAPdDkMRM0RWBp17gZw2Yxn2rUec484RUH7diauPpDW/WmK7HSnnKQIDAQAB
AoGAD0A0mxYOAh/UUXqqNrJ1jAqQBMbHJUWq5LqpL6ZfAG8rLaYEDo9DVZRGZRSi
rLjAThDnIgL2eJJbcN/x/o4ZT1+OsPwne6m26J9S98jRwOgGimHnOhkMKSz5UYlE
C6JFYiYu+CaYE+xlyai6E7VKPy9iHnVkiKfwlZF+dxba04kCQQDElB78elK6qj1M
diUytTsNL68l9W58Zv/dvPJeUe9uZN7//J5H9rtVfYgWuDs9xjcx82500BTWnURW
v/G2iRrnAkEAxplJBPcL0kJZo7BzFHTzjF5cB6iTabLKY5GUa3JiwLFbi2Oa1wy8
Q9Z5HT/qiji8mrR0BanLF5rr5RbtwNw7bwJAc2sAcn8jucOgsBciKg6seEaKEMB0
uYgELN32dBipeuiw4h4hlOEyBrToxWYwKkoKOELUlLNjuMqnyEN0mRcQ+wJBALxa
bNJ0q5WCsBl7I+nm8YXTiF0LGKRKmYDNdYJiPh6bF0Of+B61SWjdZIjFMeBd5yKi
utcULjX5DHl9wYgEV6kCQH5Eyx/3Ac1FW6d0ppwZUMuRAtxgGJWh1xHG7MLjY67p
ocufXz7DlnXYZrJUJpT+h365DNCp5dcgK8X9qmCGoX8=
-----END RSA PRIVATE KEY-----";

        private string token = SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
        SimpleHTTPClient client = new SimpleHTTPClient();

        public int SendBuyRequest(int commodity, int price, int amount)
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            BuySellRequest request = new BuySellRequest(commodity, price, amount, "buy");
            string output = SHC.SendPostRequest(Url, User, token, request);
            try
            {
                return Int32.Parse(output);
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("---" + output + "---");
                Console.ResetColor();
                return Int32.Parse(output);
            }

        }

        public bool SendCancelBuySellRequest(int id)
        {
            CancelRequest cancelRequest = new CancelRequest(id);
            string response = client.SendPostRequest(Url, User, token, cancelRequest);
            if (response.Equals("Ok"))
                return true;
            return false;
        }

        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            QueryBuySellRequest request = new QueryBuySellRequest(id);
            ItemQuery output = SHC.SendPostRequest<QueryBuySellRequest, ItemQuery>(Url, User, token, request);
            return output;
        }

        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            QueryMarketRequest request = new QueryMarketRequest(commodity);
            CommodityOffer output = SHC.SendPostRequest<QueryMarketRequest, CommodityOffer>(Url, User, token, request);
            return output;
        }

        public IMarketUserData SendQueryUserRequest()
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            QueryUserRequest request = new QueryUserRequest();
            UserData output = SHC.SendPostRequest<QueryUserRequest, UserData>(Url, User, token, request);
            return output;
        }

        public int SendSellRequest(int price, int commodity, int amount)
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            BuySellRequest request = new BuySellRequest(commodity, price, amount, "sell");
            string output = SHC.SendPostRequest(Url, User, token, request);
            int n;
            if (!int.TryParse(output, out n))
            {
                Console.WriteLine(output);
                return -1;
            }
            return Int32.Parse(output);
        }
        public AllMarketOffer[] SendQueryAllMarketRequests()
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            QueryAllMarketRequests request = new QueryAllMarketRequests();
            AllMarketOffer[] output = SHC.SendPostRequest<QueryAllMarketRequests, AllMarketOffer[]>(Url, User, token, request);
            foreach (AllMarketOffer value in output)
            {
                value.offer = (CommodityOffer)SendQueryMarketRequest(value.id);
            }
            return output;
        }
        public AllRequestsRequest[] SendQueryUserRequestsRequest()
        {
            SimpleHTTPClient SHC = new SimpleHTTPClient();
            QueryUserRequestsRequest request = new QueryUserRequestsRequest();
            AllRequestsRequest[] output = SHC.SendPostRequest<QueryUserRequestsRequest, AllRequestsRequest[]>(Url, User, token, request);
            foreach (AllRequestsRequest value in output)
            {
                value.item = (ItemQuery)SendQueryBuySellRequest(value.id);
            }
            return output;
        }

    }
}
