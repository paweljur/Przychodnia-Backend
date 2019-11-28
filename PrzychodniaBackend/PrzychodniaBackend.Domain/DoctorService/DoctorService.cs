using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo;

namespace PrzychodniaBackend.Application.DoctorService
{
    internal class DoctorService : IDoctorService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Appointment> GetDoctorsAppointments(long doctorId)
        {
            return _appointmentRepository.GetAllByDoctor(doctorId).Select(a => new Appointment(a));
        }
    }
}
