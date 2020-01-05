using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class NewUser : ValueObject
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public NewUser(string username, string password, string role, string? name, string? surname)
        {
            Username = username;
            Password = password;
            Role = role;
            Surname = surname;
            Name = name;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Username;
            yield return Password;
            yield return Role;
            yield return Surname;
            yield return Name;
        }
    }
}