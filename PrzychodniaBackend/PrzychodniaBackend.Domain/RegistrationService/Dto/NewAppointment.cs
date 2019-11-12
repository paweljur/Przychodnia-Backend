using System;
using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class NewAppointment : ValueObject
    {
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateTimeOffset AppointmentDate { get; set; }

        public NewAppointment(long patientId, long doctorId, DateTimeOffset appointmentDate)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentDate = appointmentDate;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return PatientId;
            yield return DoctorId;
            yield return AppointmentDate;
        }
    }
}