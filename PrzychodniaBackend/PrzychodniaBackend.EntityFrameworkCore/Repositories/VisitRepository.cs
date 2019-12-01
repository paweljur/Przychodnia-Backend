using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    internal class VisitRepository : IVisitRepository
    {
        private readonly AppContext _context;

        public VisitRepository(AppContext context)
        {
            _context = context;
        }

        public VisitEntity Add(AppointmentEntity appointment, string? description, string? diagnosis)
        {
            var visit = new VisitEntity(appointment, description, diagnosis); 
            _context.Visits.Add(visit);
            _context.SaveChanges();

            return visit;
        }

        public IEnumerable<VisitEntity> GetAllByDoctor(long doctorId)
        {
            return _context.Visits.Include(v => v.Appointment.Patient).Include(v => v.Appointment.Doctor).Where(v => v.Appointment.Doctor.Id == doctorId).ToList();
        }
    }
}
