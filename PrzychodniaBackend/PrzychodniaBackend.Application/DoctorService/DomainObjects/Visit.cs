using System.Collections.Generic;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects
{
    public class Visit : ValueObject
    {
        public long Id { get; set; }
        public Appointment Appointment { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }

        internal Visit(VisitEntity visit)
        {
            Id = visit.Id;
            Appointment = new Appointment(visit.Appointment);
            Description = visit.Description;
            Diagnosis = visit.Diagnosis;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Appointment;
            yield return Description;
            yield return Diagnosis;
        }
    }
}