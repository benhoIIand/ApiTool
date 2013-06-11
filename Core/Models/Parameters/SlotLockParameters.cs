using System;

namespace Core.Models.Parameters
{
    public class SlotLockParameters
    {
        public int RestaurantId { get; set; }
        public int PartySize { get; set; }
        public DateTime DateTime { get; set; }
        public string ResultsKey { get; set; }
        public string SecurityId { get; set; } 
    }
}