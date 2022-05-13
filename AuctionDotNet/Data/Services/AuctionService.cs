using AuctionDotNet.Data.Model;
using AuctionDotNet.Data.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionDotNet.Data.Services
{
    public class AuctionService
    {
        private readonly AppDbContext _context;

        public AuctionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Auction>> GetAllAuctionsAsync()
        {
            return await _context.Auctions.ToListAsync();
        }

        public async Task<Auction> GetAuctionByIdAsync(int id)
        {
            return await _context.Auctions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAuctionAsync(AuctionVM auction)
        {
            var _auction = new Auction()
            {
                Name = auction.Name,
                Description = auction.Description,
                PriceStart = auction.PriceStart,
                MaxPeriod = auction.MaxPeriod,
                MinPrice = auction.MinPrice,
                Active = auction.Active,
                AppUserId = auction.AppUserId
            };
            await _context.Auctions.AddAsync(_auction);
            await _context.SaveChangesAsync();
        }

        public async Task<Auction> UpdateAuctionByIdAsync(int auctionId, AuctionVM auction)
        {
            var _auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == auctionId);
            if(_auction != null)
            {
                _auction.Name = auction.Name;
                _auction.Description = auction.Description;
                _auction.PriceStart = auction.PriceStart;
                _auction.MaxPeriod = auction.MaxPeriod;
                _auction.MinPrice = auction.MinPrice;
                _auction.Active = auction.Active;
                _auction.AppUserId = auction.AppUserId;

                await _context.SaveChangesAsync();
            }
            return _auction;
        }

        public async Task DeleteAuctionByIdAsync(int auctionId)
        {
            var _auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == auctionId);
            if (_auction != null)
            {
                _context.Auctions.Remove(_auction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
