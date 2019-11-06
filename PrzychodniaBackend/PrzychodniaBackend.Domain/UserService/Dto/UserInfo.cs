using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class UserInfo : ValueObject
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public UserInfo(long id, string username, string role, string? name, string? surname)
        {
            Id = id;
            Username = username;
            Role = role;
            Surname = surname;
            Name = name;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Username;
            yield return Role;
            yield return Surname;
            yield return Name;
        }
    }
}