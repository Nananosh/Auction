using System;
using Auction.DataBaseConnection;
using Auction.DataBaseConnection.Factory;
using Auction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Auction.Controllers
{
    public class LotsController : Controller
    {
        
        // GET
        public IActionResult Index()
        {
            var lots = Factory.GetAllLots(DatabaseConnection.GetAllLotInformation());
            ViewBag.lots = lots;
            return View();
        }

        public IActionResult LotsAtAuction()
        {
            return View();
        }
        public IActionResult PurchasedLots()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Lot(int lotId)
        {
            ViewBag.LotId = lotId;
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
        public IActionResult Bet(Bets bets, string returnUrl)
        {
            Factory.UpdateProfileBalanace(bets.ProfileId,Factory.GetProfileBalanace(DatabaseConnection.GetProfileBalanace(bets.ProfileId))-bets.Bet);
            Factory.InsertBets(bets.ProfileId,bets.LotId,bets.Bet);
            Console.WriteLine($"{bets.ProfileId},{bets.LotId},{bets.Bet}");
            return Redirect(returnUrl);
        }
        [HttpGet]
        [Authorize]
        public IActionResult CreateLot()
        {
            var lastLotId = Factory.GetLastLotId(DatabaseConnection.GetAllLotInformation());
            ViewBag.LastLotId = lastLotId+1;
            return View();
        }
        [HttpPost]
        public IActionResult CreateLot(Lot lot, int profileId)
        {
            Factory.InsertLots(lot, profileId);
            Factory.InsertLotOwners(profileId,lot.Id);
            return Redirect("/");
        }

        public IActionResult AllLots()
        {
            var lots = Factory.GetAllLots(DatabaseConnection.GetAllLotInformation());
            ViewBag.lots = lots;
            return View();
        }
        public IActionResult CheckBets()
        {
            return View();
        }
    }
}