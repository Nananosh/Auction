using System;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using static Auction.DataBaseConnection.DatabaseConnection;

namespace Auction.TimerSoldOut
{
    public static class SoldOut 

    {
    public static void SoldOutTimer()
    {
        int lotId;
        string endOfAuctionDate;
        DateTime lotdateTime = new DateTime();
        foreach (var idAndDate in Factory.GetEndOfAuctionDate(DatabaseConnection.GetEndOfAuctionDate()))
        {
            lotId = idAndDate.Item1;
            endOfAuctionDate = idAndDate.Item2;
            lotdateTime = DateTime.ParseExact(endOfAuctionDate, "yyyy-M-dd", null);
            if (lotdateTime <= DateTime.Today)
            {
                var profileIdAndMaxBet = Factory.GetProfileIdAndMaxBet(GetProfileIdAndMaxBet(lotId));
                Factory.UpdateLotOwners(profileIdAndMaxBet.Item1,lotId);
                Factory.UpdateLotSodlOut(lotId);
                Console.WriteLine("Сработало");
            }
            else
            {
                Console.WriteLine("Не робит");
            }
        }
    }
    }
}