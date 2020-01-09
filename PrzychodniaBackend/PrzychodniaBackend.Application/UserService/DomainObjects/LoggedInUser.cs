using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.UserService.DomainObjects
{
    public class LoggedInUser
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
    }
}