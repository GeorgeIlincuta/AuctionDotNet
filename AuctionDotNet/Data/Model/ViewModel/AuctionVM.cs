using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuctionDotNet.Data.Model.ViewModel
{
    public class AuctionVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Starting bid is required")]
        public int BidStartPrice { get; set; }
        [Required(ErrorMessage = "Bid period time is required")]
        public int BidDuration { get; set; }
        [Required(ErrorMessage = "Buying price is required")]
        public int BidBuyingPrice { get; set; }
        public bool Active { get; set; }
    }
}
