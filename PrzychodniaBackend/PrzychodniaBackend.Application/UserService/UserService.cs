using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.UserService.DomainObjects;
using PrzychodniaBackend.Application.UserService.DomainObjects.Inputs;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces;

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
            UserEntity? user = _userRepository.GetBy(credentials.Username, credentials.Password);
            return user is { } ? new LoggedInUser(user) : null;
        }

        public UserInfo RegisterNewUser(NewUser user)
        {
            return new UserInfo(_userRepository.Add(user.Username, user.Password, user.Role, user.Name, user.Surname));
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return _userRepository.GetAll().Select(user => new UserInfo(user));
        }
    }
}