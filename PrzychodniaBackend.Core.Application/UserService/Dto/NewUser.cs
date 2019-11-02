namespace PrzychodniaBackend.Core.Application.UserService.Dto
{
    public class NewUser
    {
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string Role { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public NewUser(string role, string username, string password, string? name = null, string? surname = null)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Username = username;
            Password = password;
        }
    }
}