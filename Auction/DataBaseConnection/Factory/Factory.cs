﻿using System.Collections.Generic;
using System.Data.SQLite;
using Auction.Models;

namespace Auction.DataBaseConnection.Factory
{
    public static class Factory
    {
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
                var currentPrice = dataReader.GetInt32(5);
                var endingDate = dataReader.GetString(6);
                list.Add(new Lot(id,name,description,image,startPrice,currentPrice,endingDate));
            }
            return list;
        }

        public static void InsertBets(int profileId, int lotId, int bet)
        {
            DatabaseConnection.InsertBets(profileId,lotId,bet);
        }
    }
}