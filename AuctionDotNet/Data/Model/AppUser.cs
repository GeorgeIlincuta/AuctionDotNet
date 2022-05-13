using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace AuctionDotNet.Data.Model
{
    public class AppUser : IdentityUser<int>
    {
        public List<Auction> Auctions { get; set; }
    }
}
