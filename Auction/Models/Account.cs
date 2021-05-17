using System.ComponentModel.DataAnnotations;
using Auction.Controllers;

namespace Auction.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public Account(int id, string nickname, string password, int balance)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            Balance = balance;
        }

        public Account()
        {
            
        }
        
    }
}