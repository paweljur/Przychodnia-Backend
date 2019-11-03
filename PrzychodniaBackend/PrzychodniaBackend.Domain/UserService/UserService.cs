using PrzychodniaBackend.Application.UserService.Dto;

namespace PrzychodniaBackend.Application.UserService
{
    class UserService : IUserService
    {
        public LoggedInUser Login(LoginCredentials credentials)
        {
            return new LoggedInUser{Value = "test"};
        }
    }
}