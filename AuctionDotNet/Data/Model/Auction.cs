using System;
using System.Collections.Generic;

namespace AuctionDotNet.Data.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BidStartPrice { get; set; }
        public int BidDuration { get; set; }
        public int BidBuyingPrice { get; set; }
        public bool Active { get; set; }
        public  DateTime CreatedOn { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
