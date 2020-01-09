namespace PrzychodniaBackend.Application.UserService.DomainObjects.Inputs
{
    public class LoginCredentials
    {
        public string Username { get; }
        public string Password { get; }

        public LoginCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}