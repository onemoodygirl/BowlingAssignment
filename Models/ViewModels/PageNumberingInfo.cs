using System;
namespace MalPalBowling.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalNumItems { get; set; }

        public int NumPages => (int)Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage);
    }
}
