
namespace Auction.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int Balanace { get; set; }

        public Account(int id, string nickname, string password, int balanace)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            Balanace = balanace;
        }

        public Account()
        {
            
        }
        
    }
}