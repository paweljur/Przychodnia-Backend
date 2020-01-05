using System;

namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class AppointmentEntity
    {
        public long Id { get; private set; }
        public PatientEntity Patient { get; set; }
        public UserEntity Doctor { get; set; }
        public DateTimeOffset AppointmentDate { get; set; }
        public bool IsCancelled { get; set; }
        public bool IsAttended { get; set; }

        public AppointmentEntity(PatientEntity patient, UserEntity doctor, DateTimeOffset appointmentDate)
        {
            Patient = patient;
            Doctor = doctor;
            AppointmentDate = appointmentDate;
            IsCancelled = false;
            IsAttended = false;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private AppointmentEntity()
        {
        }
    }
}