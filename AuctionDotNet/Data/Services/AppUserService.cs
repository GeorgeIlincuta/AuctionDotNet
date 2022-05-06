using AuctionDotNet.Data.Model;
using AuctionDotNet.Data.Model.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AuctionDotNet.Data.Services
{
    public class AppUserService
    {
        private readonly AppDbContext _context;

        public AppUserService(AppDbContext context)
        {
            _context = context;
        }

        public List<AppUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public AppUser GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public void AddUser(UserVm user)
        {
            var _user = new AppUser()
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public AppUser UpdateUserById(int userId, UserVm user)
        {
            var _user = _context.Users.FirstOrDefault(a => a.Id == userId);
            if (_user != null)
            {
                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.Address = user.Address;
                _user.Password = user.Password;

                _context.SaveChanges();
            }
            return _user;
        }

        public void DeleteUserById(int userId)
        {
            var _user = _context.Users.FirstOrDefault(a => a.Id == userId);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
        }
    }
}
