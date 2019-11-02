using System.Collections.Generic;
using PrzychodniaBackend.Core.Application.UserService.Dto;

namespace PrzychodniaBackend.Core.Application.UserService
{
    public interface IUserService
    {
        void RegisterUser(NewUser newUser);
        SafeUser? Login(LoginCredentials credentials);
        IEnumerable<SafeUser> GetAllForAdministration();
    }
}
