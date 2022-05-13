using System.ComponentModel.DataAnnotations;

namespace AuctionDotNet.Data.Model.ViewModel
{
    public class AuctionVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Starting bid is required")]
        public int BidStart { get; set; }
        [Required(ErrorMessage = "Bid period time is required")]
        public int TimeLeft { get; set; }
        [Required(ErrorMessage = "Buying price is required")]
        public int BuyPrice { get; set; }
        public bool Active { get; set; }
        public AppUser LastBid { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
