using System;

namespace Core.Models.Parameters
{
    public class MakeParameters
    {
        public int RestaurantId { get; set; }
        public int PartySize { get; set; }
        public DateTime DateTime { get; set; }
        public string ResultsKey { get; set; }
        public string SecurityId { get; set; } 
        public int SlotLockId { get; set; } 
        public int OfferId { get; set; } 
        public string OfferTitle { get; set; } 
        public string Email { get; set; } 
    }
}