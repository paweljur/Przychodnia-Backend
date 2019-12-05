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
                _context.Users.AddAsync(new UserEntity
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

        public UserEntity? GetBy(string username, string password)
        {
            return _context.Users.SingleOrDefault(user => user.Username == username && user.Password == password);
        }

        public UserEntity Add(string username, string password, string role, string? name, string? surname)
        {
            UserEntity newUser = new UserEntity(role, username, password, name, surname);
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public UserEntity? GetDoctorBy(long doctorId)
        {
            return _context.Users.Where(u => u.Role == "doctor").SingleOrDefault(u => u.Id == doctorId);
        }

        public IEnumerable<UserEntity> GetAllDoctors()
        {
            return _context.Users.Where(u => u.Role == "doctor").ToList();
        }

        public UserEntity GetLaborantBy(long laborantId)
        {
            return _context.Users.Where(u => u.Role == "laborant").SingleOrDefault(u => u.Id == laborantId);
        }
    }
}