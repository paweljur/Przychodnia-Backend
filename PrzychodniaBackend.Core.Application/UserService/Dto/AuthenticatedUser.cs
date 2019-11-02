namespace PrzychodniaBackend.Core.Application.UserService.Dto
{
    public class AuthenticatedUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public AuthenticatedUser(string role, string token, string? name = null, string? surname = null)
        {
            Role = role;
            Token = token;
            Surname = surname;
            Name = name;
        }
    }
}
