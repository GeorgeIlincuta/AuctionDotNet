using AuctionDotNet.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace AuctionDotNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
    }
}
