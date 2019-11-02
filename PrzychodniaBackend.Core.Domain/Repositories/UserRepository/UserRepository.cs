using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.Core.Domain.Entities;

namespace PrzychodniaBackend.Core.Domain.Repositories.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly CoreContext _context;

        public UserRepository(CoreContext context)
        {
            _context = context;
            if(!_context.Users.Any())
            {
                _context.Users.AddAsync(new User
                (
                    "admin",
                    "admin",
                    "Qwerty1234!",
                    "Admin",
                    "Admin"
                ));
            }
            _context.SaveChangesAsync();
        }

        public User? LoginQuery(string username, string password)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public IEnumerable<User> GetAllForAdministrationQuery()
        {
            return _context.Users.AsNoTracking()
                .ToList();
        }

        public void RegisterUserCommand(string username, string password, string role, string? name, string? surname)
        {
            _context.Users.Add(new User(role, username, password, name, surname));
            _context.SaveChanges();
        }
    }
}
