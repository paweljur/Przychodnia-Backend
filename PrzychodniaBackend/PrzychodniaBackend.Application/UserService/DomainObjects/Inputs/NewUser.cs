namespace PrzychodniaBackend.Application.UserService.DomainObjects.Inputs
{
    public class NewUser
    {
        public string Name { get; }
        public string Surname { get; }
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }

        public NewUser(string username, string password, string role, string name, string surname)
        {
            Username = username;
            Password = password;
            Role = role;
            Surname = surname;
            Name = name;
        }
    }
}