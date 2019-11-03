using System;

namespace PrzychodniaBackend.Registration.Domain
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTimeOffset AppointmentDate { get; set; }
        public virtual Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
