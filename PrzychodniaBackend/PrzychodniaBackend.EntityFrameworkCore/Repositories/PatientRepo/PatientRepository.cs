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

        public void Add(string identityNumber, string? name, string? surname)
        {
            _context.Add(new PatientEntity(identityNumber, name, surname));
            _context.SaveChanges();
        }

        public IEnumerable<PatientEntity> GetAll()
        {
            return _context.Patients.AsNoTracking().ToList();
        }
    }
}
