using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Reflection.Metadata.Ecma335;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using Auction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class LotsController : Controller
    {
        
        // GET
        public IActionResult Index()
        {
            var lots = Factory.GetAllLots(DatabaseConnection.GetLotInformation());
            ViewBag.lots = lots;
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult Bet(int lotId)
        {
            ViewBag.LotId = lotId;
            return View();
        }
        [HttpPost]
        public void Bet(Bets bets)
        {
            Factory.InsertBets(bets.ProfileId,bets.LotId,bets.Bet);
            Console.WriteLine($"{bets.ProfileId},{bets.LotId},{bets.Bet}");
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateLot()
        {
            var lastLotId = Factory.GetLastLotId(DatabaseConnection.GetLotInformation());
            ViewBag.LastLotId = lastLotId+1;
            return View();
        }
        [HttpPost]
        public void CreateLot(Lot lot, int profileId)
        {
            Factory.InsertLots(lot, profileId);
            Factory.InsertLotOwners(profileId,lot.Id);
            Console.WriteLine(lot);
        }
    }
}