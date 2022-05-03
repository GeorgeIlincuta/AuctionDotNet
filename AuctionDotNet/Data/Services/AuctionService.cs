using AuctionDotNet.Data.Model;
using AuctionDotNet.Data.Model.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AuctionDotNet.Data.Services
{
    public class AuctionService
    {
        private readonly AppDbContext _context;

        public AuctionService(AppDbContext context)
        {
            _context = context;
        }

        public List<Auction> GetAllAuctions()
        {
            return _context.Auctions.ToList();
        }

        public Auction GetAuctionById(int id)
        {
            return _context.Auctions.FirstOrDefault(a => a.Id == id);
        }

        public void AddAuction(AuctionVM auction)
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
            _context.Auctions.Add(_auction);
            _context.SaveChanges();
        }

        public Auction UpdateAuctionById(int auctionId, AuctionVM auction)
        {
            var _auction = _context.Auctions.FirstOrDefault(a => a.Id == auctionId);
            if(_auction != null)
            {
                _auction.Name = auction.Name;
                _auction.Description = auction.Description;
                _auction.PriceStart = auction.PriceStart;
                _auction.MaxPeriod = auction.MaxPeriod;
                _auction.MinPrice = auction.MinPrice;
                _auction.Active = auction.Active;
                _auction.AppUserId = auction.AppUserId;

                _context.SaveChanges();
            }
            return _auction;
        }

        public void DeleteAuctionById(int auctionId)
        {
            var _auction = _context.Auctions.FirstOrDefault(a => a.Id == auctionId);
            if (_auction != null)
            {
                _context.Auctions.Remove(_auction);
                _context.SaveChanges();
            }
        }
    }
}
