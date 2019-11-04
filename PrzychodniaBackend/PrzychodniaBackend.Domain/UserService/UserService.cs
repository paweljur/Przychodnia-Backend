using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.Application.UserService
{
    internal class UserService : IUserService
    {
        public LoggedInUser Login(LoginCredentials credentials)
        {
            return new LoggedInUser("name", "surname");
        }
    }
}