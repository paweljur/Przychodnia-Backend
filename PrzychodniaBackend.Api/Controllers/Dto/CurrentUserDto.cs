namespace PrzychodniaBackend.Api.Controllers.Dto
{
    public class CurrentUserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        public CurrentUserDto(string role, string token, string? name = null, string? surname = null)
        {
            Role = role;
            Token = token;
            Surname = surname;
            Name = name;
        }
    }
}
