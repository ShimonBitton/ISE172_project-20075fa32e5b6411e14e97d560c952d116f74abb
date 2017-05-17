using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using MarketClient.Utils;
using MarketClient;

namespace PL
{
    public class main
    {
        static void Main(string[] args)
        {
            Boolean Esc = true;
            int price = -1, amount = -1, commodity = -1, id = -1;
            String request;
            BL.MarketClientStock MCS = new BL.MarketClientStock();
            Console.Write("Welcome! Please type your request number!");
            Console.WriteLine("\n" + "\n" + "\n" + "1: Buy" + "\n" + "2: Sell" + "\n" + "3: Cancel a buy/sell request" + "\n" + "4: Query about an item " + "\n" + "5: Query about the market state of a logged in user " + "\n" + "6: Query about a sell/buy request" + "\n" + "7: Exit" + "\n");

            while (Esc)
            {
            MainMenu:
                Console.Write("---->");
                request = Console.ReadLine();


                switch (request)
                {

                    case "1"://Buy

                        try
                        {
                            Console.Write("Please enter the commodity : ");
                            commodity = int.Parse(Console.ReadLine());
                            Console.Write("Please enter the price : ");
                            price = int.Parse(Console.ReadLine());
                            Console.Write("Please enter the amount : ");
                            amount = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine();
                            Console.WriteLine("---Invalid input---");
                            Console.WriteLine();
                            Console.WriteLine("Invalid input. Returning to main menu (Enter new command)");
                            goto MainMenu;
                        }
                        catch (OverflowException) //Int too big
                        {
                            Console.WriteLine();
                            Console.WriteLine("---Invalid input---");
                            Console.WriteLine();
                            Console.WriteLine("Invalid input. Returning to main menu (Enter new command)");
                            goto MainMenu;
                        }
                        try
                        {
                            Console.WriteLine("Request ID: " + MCS.SendBuyRequest(commodity, price, amount));
                        }
                        catch (FormatException e) //Exception from the server
                        {
                            Console.WriteLine();
                            goto MainMenu;
                        }
                        break;


                    case "2"://Sell
                        try
                        {
                            Console.Write("Please enter the commodity : ");
                            commodity = int.Parse(Console.ReadLine());
                            Console.Write("Please enter the price : ");
                            price = int.Parse(Console.ReadLine());
                            Console.Write("Please enter the amount : ");
                            amount = int.Parse(Console.ReadLine());
                            if (MCS.SendSellRequest(price, commodity, amount) == -1)
                                goto MainMenu;
                            Console.WriteLine("Your request is submitted successfully! Your request's ID is : "+MCS.SendSellRequest(price, commodity, amount));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(MCS.SendSellRequest(price, commodity, amount));
                            goto MainMenu;
                        }
                        Console.Write("\n");
                        break;

                    case "3"://Cancel request

                        try
                        {
                            Console.WriteLine("Please enter the request's ID you'd wish to cancel : ");
                            id = int.Parse(Console.ReadLine());
                            if (MCS.SendCancelBuySellRequest(id))
                                Console.WriteLine("The cancellation is done successfully.");
                            else
                                Console.WriteLine("Cancellation failed.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "6"://Specific request query
                        try
                        {
                            Console.WriteLine("Please enter the request ID: ");
                            id = Int32.Parse(Console.ReadLine());
                            Console.WriteLine(MCS.SendQueryBuySellRequest(id).ToString());

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        catch (MarketException)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "5"://User query
                        try
                        {
                            Console.WriteLine(MCS.SendQueryUserRequest().ToString());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "4"://Item query
                        try
                        {
                            Console.WriteLine("Please enter the commodity ID of the item you want to know about: ");
                            commodity = int.Parse(Console.ReadLine());
                            Console.WriteLine(MCS.SendQueryMarketRequest(commodity));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "7"://Exit
                        Esc = false;
                        break;

                    case "8":
                        try
                        {
                            AllRequestsRequest[] output = MCS.SendQueryUserRequestsRequest();
                            foreach (AllRequestsRequest value in output)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "9":
                        try
                        {
                            AllMarketOffer[] output = MCS.SendQueryAllMarketRequests();
                            foreach (AllMarketOffer value in output)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input");
                            goto MainMenu;
                        }
                        break;

                    case "10":
                        AMA runAMA = new AMA();
                        try
                        {

                            runAMA.run();
                            Console.ReadLine();
                            runAMA.stopTimer();
                        }
                        catch (Exception)
                        {
                            runAMA.stopTimer();
                        }
                        break;


                    default://When an invalid number is inserted
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
