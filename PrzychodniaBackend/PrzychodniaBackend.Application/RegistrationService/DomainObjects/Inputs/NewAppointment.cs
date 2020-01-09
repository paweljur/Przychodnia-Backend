using System;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs
{
    public class NewAppointment
    {
        public long PatientId { get; }
        public long DoctorId { get; }
        public DateTimeOffset AppointmentDate { get; }

        public NewAppointment(long patientId, long doctorId, DateTimeOffset appointmentDate)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
        }
    }
}