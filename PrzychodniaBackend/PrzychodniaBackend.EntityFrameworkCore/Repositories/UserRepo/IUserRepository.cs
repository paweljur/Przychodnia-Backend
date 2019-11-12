using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo
{
    public interface IUserRepository
    {
        UserEntity? GetBy(string username, string password);
        void Add(string username, string password, string role, string? name, string? surname);
        IEnumerable<UserEntity> GetAll();
        UserEntity? GetDoctorBy(long doctorId);
    }
}
