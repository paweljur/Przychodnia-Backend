using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.UserService.DomainObjects
{
    public class UserInfo
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
    }
}