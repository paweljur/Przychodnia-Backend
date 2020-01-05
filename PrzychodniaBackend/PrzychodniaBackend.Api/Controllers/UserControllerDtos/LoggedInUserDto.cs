using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.UserControllerDtos
{
    public class LoggedInUserDto : ValueObject
    {
        public string Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string Role { get; private set; }
        public string Token { get; private set; }

        public LoggedInUserDto(string id, string? name, string? surname, string role, string token)
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