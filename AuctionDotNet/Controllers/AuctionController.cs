﻿using AuctionDotNet.Data.Model.ViewModel;
using AuctionDotNet.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly AuctionService _auctionsService;

        public AuctionController(AuctionService auctionsService)
        {
            _auctionsService = auctionsService;
        }

        [HttpGet("get-all-auctions")]
        public async Task<IActionResult> GetAllAuctions()
        {
            var allAuctions = await _auctionsService.GetAllAuctionsAsync();
            return Ok(allAuctions);
        }

        [HttpGet("get-auction-by-id/{id}")]
        public async Task<IActionResult> GetAuctionById(int id)
        {
            var auction = await _auctionsService.GetAuctionByIdAsync(id);
            return Ok(auction);
        }

        [HttpPost("add-auction")]
        public async Task<IActionResult> AddAuction([FromBody] AuctionVM auction)
        {
            await _auctionsService.AddAuctionAsync(auction);
            return Ok();
        }

        [HttpPut("update-auction-by-id/{id}")]
        public async Task<IActionResult> UpdateAuction(int id, [FromBody]AuctionVM auction)
        {
            var updateAuction = await _auctionsService.UpdateAuctionByIdAsync(id, auction);
            return Ok(updateAuction);
        }

        [HttpDelete("delete-auction-by-id/{id}")]
        public async Task<IActionResult> DeleteAuctionById(int id)
        {
            await _auctionsService.DeleteAuctionByIdAsync(id);
            return Ok();
        }
    }
}
