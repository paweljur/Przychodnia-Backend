using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class LoginCredentials : ValueObject
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Username;
            yield return Password;
        }
    }
}