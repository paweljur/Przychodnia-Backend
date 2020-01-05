using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.DomainObjects.Inputs
{
    public class LoginCredentials : ValueObject
    {
        public string Username { get; }
        public string Password { get; }

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