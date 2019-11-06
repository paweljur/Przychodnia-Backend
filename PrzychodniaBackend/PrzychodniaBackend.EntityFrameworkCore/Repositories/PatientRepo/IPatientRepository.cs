using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.PatientRepo
{
    public interface IPatientRepository
    {
        void Add(string identityNumber, string? name, string? surname);
        IEnumerable<PatientEntity> GetAll();
    }
}
