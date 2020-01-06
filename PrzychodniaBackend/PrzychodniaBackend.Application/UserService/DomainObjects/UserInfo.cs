using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.DomainObjects
{
    public class UserInfo : ValueObject
    {
        public long Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Username { get; }
        public string Role { get; }

        internal UserInfo(UserEntity user)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Username = user.Username;
            Role = user.Role;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Username;
            yield return Role;
            yield return Surname;
            yield return Name;
        }
    }
}