using System.Linq;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo
{
    internal class UserRepository : IUserRepository
    {
        private readonly AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
            if (!_context.Users.Any())
            {
                _context.Users.AddAsync(new User
                (
                    "admin",
                    "admin",
                    "Qwerty1234!",
                    "Admin",
                    "Admin"
                ));
                _context.SaveChangesAsync();
            }
        }

        public User? GetBy(string username, string password)
        {
            return _context.Users.FirstOrDefault();
        }
    }
}