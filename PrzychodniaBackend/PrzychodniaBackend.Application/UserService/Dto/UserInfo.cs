using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
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