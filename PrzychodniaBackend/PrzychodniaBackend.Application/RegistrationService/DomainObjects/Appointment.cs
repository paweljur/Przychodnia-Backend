using System;
using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects
{
    public class Appointment : ValueObject
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

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Patient;
            yield return Doctor;
            yield return AppointmentDate;
        }
    }
}