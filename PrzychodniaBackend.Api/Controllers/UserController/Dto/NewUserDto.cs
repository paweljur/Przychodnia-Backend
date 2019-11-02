namespace PrzychodniaBackend.Api.Controllers.UserController.Dto
{
    public class NewUserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Role { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}