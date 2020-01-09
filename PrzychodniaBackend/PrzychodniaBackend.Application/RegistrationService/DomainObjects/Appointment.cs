using System;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects
{
    public class Appointment
    {
        public long Id { get; }
        public Patient Patient { get; }
        public Doctor Doctor { get; }
        public DateTimeOffset AppointmentDate { get; }

        internal Appointment(AppointmentEntity appointment)
        {
            Id = appointment.Id;
            Patient = new Patient(appointment.Patient);
            Doctor = new Doctor(appointment.Doctor);
            AppointmentDate = appointment.AppointmentDate;
        }
    }
}