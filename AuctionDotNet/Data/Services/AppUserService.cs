using AuctionDotNet.Data.Model;
using AuctionDotNet.Data.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionDotNet.Data.Services
{
    public class AppUserService
    {
        private readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddUserAsync(UserVm user)
        {
            var _user = new AppUser()
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password
            };
            await _context.Users.AddAsync(_user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> UpdateUserByIdAsync(int userId, UserVm user)
        {
            var _user = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.Address = user.Address;
                _user.Password = user.Password;

                await _context.SaveChangesAsync();
            }
            return _user;
        }

        public async Task DeleteUserByIdAsync(int userId)
        {
            var _user = await _context.Users.FirstOrDefaultAsync(a => a.Id == userId);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
