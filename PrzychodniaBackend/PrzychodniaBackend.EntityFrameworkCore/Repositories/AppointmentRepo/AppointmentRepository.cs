using System;
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

        public void CreateAppointment(PatientEntity patient, User doctor, DateTimeOffset appointmentDate)
        {
            _context.Appointment.Add(new AppointmentEntity(patient, doctor, appointmentDate));
            _context.SaveChanges();
        }
    }
}