using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _context.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
        }

        public void Add(string username, string password, string role, string? name, string? surname)
        {
            _context.Users.Add(new User(role, username, password, name, surname));
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }
    }
}