namespace PrzychodniaBackend.Api.Authentication
{
    public interface IJwtService
    {
        string GenerateToken(string userId);
    }
}
