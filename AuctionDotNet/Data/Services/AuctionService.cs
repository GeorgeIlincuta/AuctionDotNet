using AuctionDotNet.Data.Model;
using AuctionDotNet.Data.Model.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionDotNet.Data.Services
{
    public class AuctionService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AuctionService(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                Title = auction.Title,
                Description = auction.Description,
                BidStartPrice = auction.BidStartPrice,
                BidDuration = auction.BidDuration,
                BidBuyingPrice = auction.BidBuyingPrice,
                Active = auction.Active,
                CreatedOn = DateTime.Now,
                AppUserId = 4,
                //await _context.Users.FirstOrDefault(e => e.email == auction.AppUserEmail)
            };
            await _context.Auctions.AddAsync(_auction);
            await _context.SaveChangesAsync();
        }

        public async Task<Auction> UpdateAuctionByIdAsync(int auctionId, AuctionVM auction)
        {
            var _auction = await _context.Auctions.FirstOrDefaultAsync(a => a.Id == auctionId);
            if(_auction != null)
            {
                _auction.Title = auction.Title;
                _auction.Description = auction.Description;
                _auction.BidStartPrice = auction.BidStartPrice;
                _auction.BidDuration = auction.BidDuration;
                _auction.BidBuyingPrice = auction.BidBuyingPrice;
                _auction.Active = auction.Active;
                _auction.CreatedOn = DateTime.Now;
                _auction.AppUserId = 4;

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

        //private async Task GetUserId()
        //{
        //    return await _userManager.GetUserAsync(User);
        //    //return _userManager?.User as ClaimsPrincipal;
        //    //return _userManager.GetUserId(User);
        //    //return _context.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        //}
    }
}
