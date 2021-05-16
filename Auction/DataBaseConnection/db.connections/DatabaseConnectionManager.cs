using System.Data.SQLite;
namespace Auction.DataBaseConnection
{
    public class DatabaseConnectionManager
    {
        private DatabaseConnectionManager()
        {
        }

        private static string GetConnectionString()
        {
            // return $"Data Source={Path.GetFullPath("DatabaseConnection/zodiacs.sqlite")};"; TODO optimize
            return
                @"Data Source=C:\Users\nanan\RiderProjects\Auction\Auction\DataBaseConnection\auction.sqlite";
        }

        public static SQLiteConnection GetSqlConnection()
        {
            return new(GetConnectionString(), true);
        }
    }
}