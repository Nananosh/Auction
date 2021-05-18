using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.SQLite;
using Auction.Models;

namespace Auction.DataBaseConnection.Factory
{
    public static class Factory
    {
        public static (int, int) GetProfileIdAndMaxBet(SQLiteDataReader dataReader)
        {
            var idAndMaxBet=(0,0);
            while (dataReader.Read())
            {
                idAndMaxBet = (dataReader.GetInt32(0),dataReader.GetInt32(1));
            }
            return idAndMaxBet;
        }
        public static List<(int,string)> GetEndOfAuctionDate(SQLiteDataReader dataReader)
        {
            List<(int lotId, string EndOfAuctionDate)> list = new List<(int lotId, string EndOfAuctionDate)>();
            while (dataReader.Read())
            {
                var idAndEndDate  = (lotId :dataReader.GetInt32(0),EndOfAuctionDate:dataReader.GetString(1));
                list.Add(idAndEndDate);
            }
            return list;
        }
        public static List<Account> GetProfielInformation(SQLiteDataReader dataReader)
        {
            List<Account> list = new List<Account>();
            while (dataReader.Read())
            {
                var id = dataReader.GetInt32(0);
                var nickname = dataReader.GetString(1);
                var password = dataReader.GetString(2);
                var balanace = dataReader.GetInt32(3);
                list.Add(new Account(id,nickname,password,balanace));
            }
            return list;
        }
        public static List<Lot> GetAllLots(SQLiteDataReader dataReader)
        {
            List<Lot> list = new List<Lot>();
            while (dataReader.Read())
            {
                var id = dataReader.GetInt32(0);
                var name = dataReader.GetString(1);
                var description = dataReader.GetString(2);
                var image = dataReader.GetString(3);
                var startPrice = dataReader.GetInt32(4);
                var currentPrice = dataReader.GetInt32(7);
                var soldOut = dataReader.GetInt32(5);
                var endingDate = dataReader.GetString(6);
                list.Add(new Lot(id,name,description,image,startPrice,currentPrice,soldOut,endingDate));
            }
            return list;
        }
        public static int GetLastLotId(SQLiteDataReader dataReader)
        {
            int lastLotId = 0;
            while (dataReader.Read())
            {
                lastLotId = dataReader.GetInt32(0);
            }
            return lastLotId;
        }

        public static void InsertBets(int profileId, int lotId, int bet)
        {
            DatabaseConnection.InsertBets(profileId,lotId,bet);
        }
        public static void InsertLots(Lot lot, int profileId)
        {
            DatabaseConnection.InsertLots(lot, profileId);
        }

        public static void InsertProfile(Account account)
        {
            DatabaseConnection.InsertProfile(account);
        }

        public static void InsertLotOwners(int profileId, int lotId)
        {
            DatabaseConnection.InsertLotOwners(profileId,lotId);
        }

        public static void UpdateLotOwners(int profileId, int lotId)
        {
            DatabaseConnection.UpdateLotOwners(profileId,lotId);
        }

        public static void UpdateLotSodlOut(int lotId)
        {
            DatabaseConnection.UpdateLotSodlOut(lotId);
        }
        public static void UpdateCurrentPrice(int lotId)
        {
            
        }
    }
    
}