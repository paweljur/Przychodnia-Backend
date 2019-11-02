using PrzychodniaBackend.Core.Domain.Entities;

namespace PrzychodniaBackend.Core.Application.UserService.Dto
{
    public class SafeUser
    {
        public long Id { get; }
        public string Role { get; }
        public string Username { get; }
        public string? Name { get; }
        public string? Surname { get; }

        public SafeUser(long id, string role, string username, string? name, string? surname)
        {
            Id = id;
            Role = role;
            Username = username;
            Name = name;
            Surname = surname;
        }

        internal SafeUser(User user)
        {
            Id = user.Id;
            Role = user.Role;
            Username = user.Username;
            Name = user.Name;
            Surname = user.Surname;
        }
    }
}