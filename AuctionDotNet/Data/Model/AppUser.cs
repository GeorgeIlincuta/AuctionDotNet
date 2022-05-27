using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AuctionDotNet.Data.Model
{
    public class AppUser : IdentityUser<int>
    {
        public List<Auction> Auctions { get; set; }
        public List<AuctionBought> AuctionsBought { get; set; }
        public List<AuctionBid> AuctionBids { get; set; }
    }
}
