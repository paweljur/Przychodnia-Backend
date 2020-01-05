using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.UserControllerDtos
{
    public class LoggedInUserDto : ValueObject
    {
        public string Id { get; }
        public string Name { get;  }
        public string Surname { get; }
        public string Role { get; }
        public string Token { get; }

        public LoggedInUserDto(string id, string name, string surname, string role, string token)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
            Token = token;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
            yield return Role;
            yield return Token;
        }
    }
}