using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class LoggedInUser : ValueObject
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string Role { get; private set; }

        internal LoggedInUser(UserEntity user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Role = user.Role;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
            yield return Role;
        }
    }
}