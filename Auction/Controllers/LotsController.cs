using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using Auction.Models;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class LotsController : Controller
    {
        
        // GET
        public IActionResult Index()
        {
            var lots = Factory.GetAllLots(DatabaseConnection.GetTable("lots"));
            ViewBag.lots = lots;
            return View();
        }
        [HttpGet]
        public IActionResult Bet(int lotId)
        {
            ViewBag.LotId = lotId;
            return View();
        }
        [HttpPost]
        public void Bet(Bets bets)
        {
            Factory.InsertBets(bets.ProfileId,bets.LotId,bets.Bet);
        }
    }
}