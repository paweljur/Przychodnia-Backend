using System.Collections.Generic;
using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.Application.UserService
{
    public interface IUserService
    {
        LoggedInUser? Login(LoginCredentials credentials);
        UserInfo RegisterNewUser(NewUser newUser);
        IEnumerable<UserInfo>  GetAllUsers();
    }
}
