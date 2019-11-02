namespace PrzychodniaBackend.Api.Services
{
    public interface IJwtService
    {
        string GenerateToken(long userId);
    }
}