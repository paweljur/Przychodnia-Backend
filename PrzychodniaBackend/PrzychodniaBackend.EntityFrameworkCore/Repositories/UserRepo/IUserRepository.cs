using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo
{
    public interface IUserRepository
    {
        User? GetBy(string username, string password);
    }
}
