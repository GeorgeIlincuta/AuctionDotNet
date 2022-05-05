using AuctionDotNet.Data.Model.ViewModel;
using AuctionDotNet.Data.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("MyCorsImplementationPolicy")]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionService _auctionsService;

        public AuctionController(AuctionService auctionsService)
        {
            _auctionsService = auctionsService;
        }

        [HttpGet("get-all-auctions")]
        public IActionResult GetAllAuctions()
        {
            var allAuctions = _auctionsService.GetAllAuctions();
            return Ok(allAuctions);
        }

        [HttpGet("get-auction-by-id/{id}")]
        public IActionResult GetAuctionById(int id)
        {
            var auction = _auctionsService.GetAuctionById(id);
            return Ok(auction);
        }

        [HttpPost("add-auction")]
        public IActionResult AddAuction([FromBody] AuctionVM auction)
        {
            _auctionsService.AddAuction(auction);
            return Ok();
        }

        [HttpPut("update-auction-by-id/{id}")]
        public IActionResult UpdateAuction(int id, [FromBody]AuctionVM auction)
        {
            var updateAuction = _auctionsService.UpdateAuctionById(id, auction);
            return Ok(updateAuction);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteAuctionById(int id)
        {
            _auctionsService.DeleteAuctionById(id);
            return Ok();
        }
    }
}
