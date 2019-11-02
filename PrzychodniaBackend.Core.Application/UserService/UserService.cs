using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Core.Application.UserService.Dto;
using PrzychodniaBackend.Core.Domain.Repositories.UserRepository;

namespace PrzychodniaBackend.Core.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public SafeUser? Login(LoginCredentials credentials)
        {
            return _userRepository.LoginQuery(credentials.Username, credentials.Password) is { } user ? new SafeUser(user) : null;
        }

        public IEnumerable<SafeUser> GetAllForAdministration()
        {
            return _userRepository.GetAllForAdministrationQuery().Select(user => new SafeUser(user));
        }

        public void RegisterUser(NewUser newUser)
        {
            _userRepository.RegisterUserCommand(newUser.Username, newUser.Password, newUser.Role, newUser.Name,
                newUser.Surname);
        }
    }
}