using System;
using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs
{
    public class NewAppointment : ValueObject
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

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return PatientId;
            yield return DoctorId;
            yield return AppointmentDate;
        }
    }
}