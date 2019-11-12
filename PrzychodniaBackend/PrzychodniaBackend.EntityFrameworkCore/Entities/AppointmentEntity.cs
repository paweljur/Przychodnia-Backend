using System;

namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class AppointmentEntity
    {
        public long Id { get; private set; }
        public PatientEntity Patient { get; private set; }
        public User Doctor { get; private set; }
        public DateTimeOffset AppointmentDate { get; private set; }

        public AppointmentEntity(PatientEntity patient, User doctor, DateTimeOffset appointmentDate)
        {
            Patient = patient;
            Doctor = doctor;
            AppointmentDate = appointmentDate;
        }

        private AppointmentEntity(DateTimeOffset appointmentDate)
        {
            AppointmentDate = appointmentDate;
        }
    }
}
