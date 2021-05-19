using System.Collections.Generic;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;

namespace Auction.TimerSoldOut
{
    public static class UpdateLotOwnersAndSoldOutInformation
    {
        public static void UpdateLotOwnersAndSoldOut(int profileId, int lotId)
        {
            Factory.UpdateLotOwners(profileId,lotId);
            Factory.UpdateLotSodlOut(lotId);
        }

        public static void ReturnProfileBalance(List<(int, int)> profileIdAndMaxBet,int lotCreator)
        {
            for (int i = 0; i < profileIdAndMaxBet.Count; i++)
            {
                if (profileIdAndMaxBet[i].Item1 !=
                    lotCreator)
                {
                    Factory.UpdateProfileBalanace(profileIdAndMaxBet[i].Item1,(Factory.GetProfileBalanace(DatabaseConnection.GetProfileBalanace(profileIdAndMaxBet[i].Item1))+profileIdAndMaxBet[i].Item2));

                }
                else
                {
                    break;
                }
            }
        }
    }
}