namespace PrzychodniaBackend.Api.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(long id, string role, string username, string password, string? name = null, string? surname = null)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Role = role;
            Username = username;
            Password = password;
        }
    }
}
