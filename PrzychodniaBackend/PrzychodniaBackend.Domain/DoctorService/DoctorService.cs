using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo;

namespace PrzychodniaBackend.Application.DoctorService
{
    internal class DoctorService : IDoctorService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVisitRepository _visitRepository;

        public DoctorService(IAppointmentRepository appointmentRepository, IVisitRepository visitRepository)
        {
            _appointmentRepository = appointmentRepository;
            _visitRepository = visitRepository;
        }

        public IEnumerable<Appointment> GetDoctorsAppointments(long doctorId)
        {
            return _appointmentRepository.GetAllByDoctor(doctorId).Select(a => new Appointment(a));
        }

        // ToDo null check
        public void CancelAppointment(long appointmentId)
        {
            AppointmentEntity? appointment = _appointmentRepository.GetTracked(appointmentId);
            appointment.IsCancelled = true;
            _appointmentRepository.Save();
        }

        // ToDo null check
        public void FinishAppointment(VisitDetails visitDetails)
        {
            AppointmentEntity? appointment = _appointmentRepository.GetTracked(visitDetails.AppointmentId);
            appointment.IsAttended = true;
            _visitRepository.Add(appointment, visitDetails.Description, visitDetails.Diagnosis);
        }
    }
}
