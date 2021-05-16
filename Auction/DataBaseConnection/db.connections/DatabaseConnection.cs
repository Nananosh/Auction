using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Auction.Models;

namespace Auction.DataBaseConnection
{
    public static class DatabaseConnection
    {
        private readonly static SQLiteConnection _connection =
            DatabaseConnectionManager.GetSqlConnection().OpenAndReturn();
        public static SQLiteDataReader GetTable(String nameTable)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"select * from {nameTable}";
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
            Console.WriteLine(command.ExecuteNonQuery());
        }

        public static void UpdateProfielBalance(int newBalance)
        {
            using var command = _connection.CreateCommand();
            command.Connection = _connection;
            command.CommandText = $"Update profiel Set balance = newBanace";
            command.Parameters.AddWithValue("balance", newBalance);
        }
    }
}