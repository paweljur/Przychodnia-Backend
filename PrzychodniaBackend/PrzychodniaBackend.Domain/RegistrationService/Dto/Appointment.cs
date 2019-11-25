using System;
using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class Appointment : ValueObject
    {
        public Patient Patient { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTimeOffset AppointmentDate { get; private set; }

        internal Appointment(AppointmentEntity appointment)
        {
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