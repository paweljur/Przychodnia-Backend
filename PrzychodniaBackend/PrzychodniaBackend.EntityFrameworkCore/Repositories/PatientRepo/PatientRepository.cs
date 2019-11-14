using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.PatientRepo
{
    internal class PatientRepository : IPatientRepository
    {
        private readonly AppContext _context;

        public PatientRepository(AppContext context)
        {
            _context = context;
        }

        public PatientEntity Add(string identityNumber, string? name, string? surname)
        {
            PatientEntity patient = new PatientEntity(identityNumber, name, surname);
            _context.Add(patient);
            _context.SaveChanges();

            return patient;
        }

        public IEnumerable<PatientEntity> GetAll()
        {
            return _context.Patients.AsNoTracking().ToList();
        }

        public PatientEntity? GetBy(long id)
        {
            return _context.Patients.SingleOrDefault(p => p.Id == id);
        }
    }
}
