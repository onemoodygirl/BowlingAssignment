using System;
using Microsoft.AspNetCore.Mvc;
using MalPalBowling.Models;
using System.Linq;

//the view components file
namespace MalPalBowling.Components
{
    public class BowlerTeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;

        public BowlerTeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }


        public IViewComponentResult Invoke()
        {
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
