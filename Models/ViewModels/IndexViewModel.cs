using System;
using System.Collections.Generic;

namespace MalPalBowling.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowler> Bowler { get; set; }

        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamName { get; set; }

        public List<Team> Teams { get; set; }
    }
}
