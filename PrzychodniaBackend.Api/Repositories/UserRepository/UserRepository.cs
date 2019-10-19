using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.Api.Entities;

namespace PrzychodniaBackend.Api.Repositories.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private readonly ApiContext _context;

        public UserRepository(ApiContext context)
        {
            _context = context;
            _context.Users.AddAsync(new User
            {
                Id = 1,
                Name = "Admin",
                Password = "Qwerty1234!",
                Role = "admin",
                Surname = "Admin",
                Username = "admin",
            });
            _context.SaveChangesAsync();
        }

        public async Task<User> GetBy(long id)
        {
            return await _context.Users.FindAsync(id);
        }

        public User? GetBy(string? username, string? password)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(u => u.Username == username && u.Password == password);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task Replace(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool Exists(long id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Delete(long id)
        {
            User? userForDeletion = await _context.Users.FindAsync(id);

            if (userForDeletion != null)
            {
                _context.Users.Remove(userForDeletion);
                await _context.SaveChangesAsync();
            }

            return userForDeletion;
        }
    }
}
