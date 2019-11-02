namespace PrzychodniaBackend.Api.Controllers.UserController.Dto
{
    public class AuthenticatedUserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public AuthenticatedUserDto(string role, string token, string? name = null, string? surname = null)
        {
            Role = role;
            Token = token;
            Surname = surname;
            Name = name;
        }
    }
}
