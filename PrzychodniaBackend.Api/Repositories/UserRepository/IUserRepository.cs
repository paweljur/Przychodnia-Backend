using System.Collections.Generic;
using System.Threading.Tasks;
using PrzychodniaBackend.Api.Entities;

namespace PrzychodniaBackend.Api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetBy(long id);
        User? GetBy(string? username, string? password);
        Task<IEnumerable<User>> GetAll();
        Task Replace(User user);
        bool Exists(long id);
        Task Add(User user);
        Task<User?> Delete(long id);
    }
}
