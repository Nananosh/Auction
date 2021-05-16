using System.Collections.Generic;
using Auction.Models;

namespace Auction.DataBaseConnection
{
    public interface IDatabaseConnection
    {
        public List<Lot> GetAllLots();
    }
}