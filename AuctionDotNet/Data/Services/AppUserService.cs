using AuctionDotNet.Data.Model;

namespace AuctionDotNet.Data.Services
{
    public class AppUserService
    {
        private readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }
    }
}
