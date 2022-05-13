using AuctionDotNet.Data.Model.ViewModel;
using AuctionDotNet.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuctionDotNet.Controllers
{
    public class UserController : Controller
    {
        private readonly AppUserService _appUserServices;

        public UserController(AppUserService appUserServices)
        {
            _appUserServices = appUserServices;
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _appUserServices.GetAllUsersAsync();
            return Ok(allUsers);
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _appUserServices.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] UserVm user)
        {
            await _appUserServices.AddUserAsync(user);
            return Ok();
        }

        [HttpPut("update-user-by-id/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserVm user)
        {
            var updateUser = await _appUserServices.UpdateUserByIdAsync(id, user);
            return Ok(updateUser);
        }

        [HttpDelete("delete-user-by-id/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            await _appUserServices.DeleteUserByIdAsync(id);
            return Ok();
        }
    }
}
