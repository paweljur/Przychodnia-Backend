using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo
{
    internal class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppContext _context;

        public AppointmentRepository(AppContext context)
        {
            _context = context;
        }

        public void CreateAppointment(PatientEntity patient, UserEntity doctor, DateTimeOffset appointmentDate)
        {
            _context.Appointment.Add(new AppointmentEntity(patient, doctor, appointmentDate));
            _context.SaveChanges();
        }

        public IEnumerable<AppointmentEntity> GetAll()
        {
            return _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToList();
        }

        public IEnumerable<AppointmentEntity> GetAllByDoctor(long doctorsId)
        {
            return _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Where(a => a.Doctor.Id == doctorsId)
                .ToList();
        }
    }
}