using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    internal class LabTestResultRepository : ILabTestResultRepository
    {
        private readonly AppContext _context;

        public LabTestResultRepository(AppContext context)
        {
            _context = context;
        }

        public void Add(LabTestResultEntity labTestResultEntity)
        {
            _context.LabTestResults.Add(labTestResultEntity);
            _context.SaveChanges();
        }

        public IEnumerable<LabTestResultEntity> GetAll()
        {
            return _context.LabTestResults.Include(r => r.LabTestOrder.Patient).Include(r => r.Laborant).ToList();
        }

        public IEnumerable<LabTestResultEntity> GetAllByPatient(long patientId)
        {
            return _context.LabTestResults.Include(r => r.Laborant).Include(r => r.LabTestOrder.Patient).Include(r => r.LabTestOrder.Doctor).Where(r => r.LabTestOrder.Patient.Id == patientId).ToList();
        }
    }
}