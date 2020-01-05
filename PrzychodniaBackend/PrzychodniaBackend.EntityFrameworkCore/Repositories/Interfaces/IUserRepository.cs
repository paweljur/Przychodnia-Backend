using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserEntity? GetBy(string username, string password);
        UserEntity Add(string username, string password, string role, string? name, string? surname);
        IEnumerable<UserEntity> GetAll();
        UserEntity? GetDoctorBy(long doctorId);
        IEnumerable<UserEntity> GetAllDoctors();
        UserEntity GetLaborantBy(long laborantId);
    }
}