using PrzychodniaBackend.Core.Domain.Entities;
using System.Collections.Generic;

namespace PrzychodniaBackend.Core.Domain.Repositories.UserRepository
{
    public interface IUserRepository
    {
        void RegisterUserCommand(string username, string password, string role, string? name, string? surname);
        User? LoginQuery(string username, string password);
        IEnumerable<User> GetAllForAdministrationQuery();
    }
}
