using System;
using System.Collections.Generic;

namespace MalPalBowling.Models.ViewModels
{
    //the view model for the index pg for the bowlers and team info
    public class IndexViewModel
    {
        public List<Bowler> Bowler { get; set; }

        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }

        public List<Team> Teams { get; set; }
    }
}
