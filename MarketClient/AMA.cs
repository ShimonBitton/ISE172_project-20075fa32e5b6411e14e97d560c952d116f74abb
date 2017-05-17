using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using System.Timers;
using MarketClient;
namespace MarketClient
{
    public class AMA
    {
        public static System.Timers.Timer aTimer;
        public static bool Stop;

        public static void SetTimer()
        {
            aTimer = new System.Timers.Timer(3000);
            aTimer.Elapsed += Algorithm;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void Algorithm(Object source, ElapsedEventArgs e)
        {
            try
            {
                if (!Stop)
                {
                    RequestManager a = new RequestManager();
                    UserData b = (UserData)a.SendQueryUserRequest();
                    int minAsk = Int32.MaxValue;
                    int maxBid = 0;
                    int askID = -1;
                    int bidID = -1;
                    int bidCommodityAmount = -1;
                    int askCommidityAmount = -1;
                    AllMarketOffer[] c = a.SendQueryAllMarketRequests();
                    foreach (AllMarketOffer value in c)
                    {
                        CommodityOffer offer = value.offer;
                        if (offer.ask < minAsk)
                        {
                            minAsk = offer.ask;
                            askID = value.id;
                        }
                        if (offer.bid > maxBid)
                        {
                            maxBid = offer.bid;
                            bidID = value.id;
                        }
                    }

                    foreach (KeyValuePair<String, int> value in b.commodities)
                    {
                        if (Convert.ToInt32(value.Key) == bidID)
                            bidCommodityAmount = value.Value;
                        if (Convert.ToInt32(value.Key) == askID)
                            askCommidityAmount = value.Value;
                    }
                    if (b.funds >= 400)
                    {
                        if(askCommidityAmount<12)
                        a.SendBuyRequest(askID, minAsk, 1);
                    }
                    if (bidCommodityAmount > 0)
                    {
                        a.SendSellRequest(
                            maxBid, bidID, 1);
                    }
                }
            }
            catch(Exception)
            {
                Stop = false;
            }
        }
        public void stopTimer()
        {
            Stop = true;
            aTimer.Stop();
            aTimer.Enabled = false;
        }

        public void run()
        {
            SetTimer();
            Stop = false;
            aTimer.Start();
        }
    }
}