using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Auction.Models;
using Microsoft.AspNetCore.Identity;

namespace Auction.DataBaseConnection
{
    public static class DatabaseConnection
    {
        private readonly static SQLiteConnection _connection =
            DatabaseConnectionManager.GetSqlConnection().OpenAndReturn();
        public static SQLiteDataReader GetProfielInformation()
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"select id,nickname,password,balanace from profiles";
            return command.ExecuteReader();
        }
        public static SQLiteDataReader GetLotInformation()
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT id,name,description,image,start_price,sold_out,ending_date,max(bet_price) as bet_price FROM lots lots LEFT JOIN bets b on lots.id = b.lot_id group by lot_id;";
            return command.ExecuteReader();
        }
        
        public static SQLiteDataReader GetLastLotId()
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT max(id) FROM lots;";
            return command.ExecuteReader();
        }
        public static SQLiteDataReader GetProfileIdAndMaxBet(int lotId)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT b.profile_id, max(bet_price) as bet_price FROM lots lots LEFT JOIN bets b on lots.id = b.lot_id where lot_id={lotId} group by lot_id;";
            return command.ExecuteReader();
        } 
        public static SQLiteDataReader GetEndOfAuctionDate()
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"SELECT id,ending_date FROM lots where sold_out=0";
            return command.ExecuteReader();
        }
        

        public static void InsertBets(int profileId, int lotId, int bet)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO bets(profile_id,lot_id,bet_price) VALUES (:profileId,:lotId,:bet);";
            command.Parameters.AddWithValue("profileId", profileId);
            command.Parameters.AddWithValue("lotId", lotId);
            command.Parameters.AddWithValue("bet", bet);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        public static void InsertLotOwners(int profileId,int lotId)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO lot_owners(profile_id,lot_id) VALUES (:profileId,:lotId);";
            command.Parameters.AddWithValue("profileId", profileId);
            command.Parameters.AddWithValue("lotId", lotId);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();   
        }

        public static void InsertLots(Lot lot, int profileId)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO lots(name, description, image, start_price,  sold_out, ending_date) " +
                                  $"VALUES (:name, :description, :image, :startPrice,  :soldOut, :endingDate);" +
                                  $"INSERT INTO bets(profile_id,lot_id,bet_price)" +
                                  $"VALUES (:profileId,:lotId, :currentPrice)";
            command.Parameters.AddWithValue("name", lot.Name);
            command.Parameters.AddWithValue("description", lot.Description);
            command.Parameters.AddWithValue("image", lot.Image);
            command.Parameters.AddWithValue("startPrice", lot.StartPrice);
            command.Parameters.AddWithValue("soldOut", lot.SoldOut);
            command.Parameters.AddWithValue("endingDate", lot.EndOfAuctionDate);
            command.Parameters.AddWithValue("profileId", profileId);
            command.Parameters.AddWithValue("lotId", lot.Id);
            command.Parameters.AddWithValue("currentPrice", lot.StartPrice);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        public static void InsertProfile(Account account)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"INSERT INTO profiles(nickname,password,balanace) VALUES (:nickname,:password,:balanace);";
            command.Parameters.AddWithValue("nickname", account.Nickname);
            command.Parameters.AddWithValue("password", account.Password);
            command.Parameters.AddWithValue("balanace", account.Balanace);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }
        public static void UpdateLotOwners(int profileId, int lotId)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"UPDATE lot_owners SET profile_id=:profileId WHERE lot_id=:lotId;";
            command.Parameters.AddWithValue("profileId", profileId);
            command.Parameters.AddWithValue("lotId",lotId );
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }
        public static void UpdateLotSodlOut(int lotId)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"UPDATE lots SET sold_out=1 WHERE id=:lotId;";
            command.Parameters.AddWithValue("lotId",lotId );
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }
        public static void UpdateProfielBalanace(int newBalanace)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"Update profile Set balanace = newBanace";
            command.Parameters.AddWithValue("balanace", newBalanace);
        }
    }
}