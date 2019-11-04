using PrzychodniaBackend.Application.UserService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo;

namespace PrzychodniaBackend.Application.UserService
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoggedInUser? Login(LoginCredentials credentials)
        {
            User? user = _userRepository.GetBy(credentials.Username, credentials.Password);
            return user is { } ? new LoggedInUser(user.Name, user.Surname) : null;
        }
    }
}