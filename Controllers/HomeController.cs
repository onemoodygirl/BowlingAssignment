using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MalPalBowling.Models;
using Microsoft.EntityFrameworkCore;
using MalPalBowling.Models.ViewModels;

namespace MalPalBowling.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private variable
        private BowlingLeagueContext context { get; set; }

        //connect to DB
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
        
        //pagination
        public IActionResult Index(long? bowlerteamid, string bowlerteamname, int pageNum = 0)
        {
            //show just 5 bowlers at a time
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowler = (context.Bowlers
                .Where(m => m.TeamId == bowlerteamid || bowlerteamid == null)
                .OrderBy(m => m.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    //if no team selected, count all, otherwise, count the number of bowlers for that team
                    TotalNumItems = (bowlerteamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == bowlerteamid).Count())
                },

                TeamName = bowlerteamname
            });   
        }
        
        //privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
