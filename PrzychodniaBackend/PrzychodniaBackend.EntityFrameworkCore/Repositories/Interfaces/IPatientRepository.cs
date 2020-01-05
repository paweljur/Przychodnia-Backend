using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        PatientEntity Add(string identityNumber, string? name, string? surname);
        IEnumerable<PatientEntity> GetAll();
        PatientEntity? GetBy(long id);
    }
}