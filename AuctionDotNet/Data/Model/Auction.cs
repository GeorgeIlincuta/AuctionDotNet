namespace AuctionDotNet.Data.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BidStart { get; set; }
        public int TimeLeft { get; set; }
        public int BuyPrice { get; set; }
        public bool Active { get; set; }
        public AppUser LastBid { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
