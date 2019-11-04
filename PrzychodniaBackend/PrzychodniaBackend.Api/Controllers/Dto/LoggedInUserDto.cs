namespace PrzychodniaBackend.Api.Controllers.Dto
{
    public class LoggedInUserDto
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Token { get; private set; }

        public LoggedInUserDto(string id, string name, string surname, string token)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Token = token;
        }
    }
}