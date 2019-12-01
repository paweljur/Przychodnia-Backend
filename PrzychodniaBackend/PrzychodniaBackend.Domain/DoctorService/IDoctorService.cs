using System.Collections.Generic;
using PrzychodniaBackend.Application.RegistrationService.Dto;

namespace PrzychodniaBackend.Application.DoctorService
{
    public interface IDoctorService
    {
        IEnumerable<Appointment> GetDoctorsAppointments(long doctorId);
        void CancelAppointment(long appointmentId);
        void FinishAppointment(VisitDetails visitDetails);
    }
}
