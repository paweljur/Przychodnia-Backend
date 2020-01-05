namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class UserEntity
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserEntity(string role, string username, string password, string name, string surname)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Username = username;
            Password = password;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private UserEntity()
        {
        }
    }
}