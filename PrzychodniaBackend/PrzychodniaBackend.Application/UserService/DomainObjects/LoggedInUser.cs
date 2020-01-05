using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.DomainObjects
{
    public class LoggedInUser : ValueObject
    {
        public long Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Role { get; }

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