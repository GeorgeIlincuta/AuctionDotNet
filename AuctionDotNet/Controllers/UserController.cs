using AuctionDotNet.Data.Model.ViewModel;
using AuctionDotNet.Data.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllUsers()
        {
            var allUsers = _appUserServices.GetAllUsers();
            return Ok(allUsers);
        }

        [HttpGet("get-user-by-id/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _appUserServices.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("add-user")]
        public IActionResult AddUser([FromBody] UserVm user)
        {
            _appUserServices.AddUser(user);
            return Ok();
        }

        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserVm user)
        {
            var updateUser = _appUserServices.UpdateUserById(id, user);
            return Ok(updateUser);
        }

        [HttpDelete("delete-user-by-id/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            _appUserServices.DeleteUserById(id);
            return Ok();
        }
    }
}
