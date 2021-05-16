using System;

namespace Auction.Models
{
    public class Lot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int StartPrice { get; set; }
        public int CurrentPrice { get; set; }
        public string EndOfAuctionDate { get; set; }

        public Lot(int id, string name, string description, string image, int startPrice, int currentPrice, string endOfAuctionDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            StartPrice = startPrice;
            CurrentPrice = currentPrice;
            EndOfAuctionDate = endOfAuctionDate;
        }
    }
}