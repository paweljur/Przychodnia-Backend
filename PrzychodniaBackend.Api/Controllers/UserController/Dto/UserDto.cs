namespace PrzychodniaBackend.Api.Controllers.UserController.Dto
{
    public class UserDto
    {
        public long Id { get; }
        public string Role { get; }
        public string Username { get; }
        public string? Name { get; }
        public string? Surname { get; }

        public UserDto(long id, string role, string username, string? name, string? surname)
        {
            Id = id;
            Role = role;
            Username = username;
            Name = name;
            Surname = surname;
        }
    }
}
