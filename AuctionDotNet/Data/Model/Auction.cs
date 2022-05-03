namespace AuctionDotNet.Data.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceStart { get; set; }
        public int MaxPeriod { get; set; }
        public int MinPrice { get; set; }
        public bool Active { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
