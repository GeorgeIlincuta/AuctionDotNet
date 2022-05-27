using AuctionDotNet.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuctionDotNet.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Auction>()
                .HasOne<AppUser>(u => u.AppUser)
                .WithMany(a => a.Auctions)
                .HasForeignKey(a => a.AppUserId);

            base.OnModelCreating(builder);
        }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
        public DbSet<AuctionBought> AuctionsBought { get; set; }
    }
}
