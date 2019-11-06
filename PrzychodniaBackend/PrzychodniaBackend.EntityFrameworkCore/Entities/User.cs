namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class User
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string Role { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        internal User(string role, string username, string password, string? name, string? surname)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Username = username;
            Password = password;
        }
    }
}