using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class Patient : ValueObject
    {
        public long Id { get; }
        public string? Name { get; }
        public string? Surname { get; }
        public string IdentityNumber { get; }

        internal Patient(PatientEntity patient)
        {
            Id = patient.Id;
            Name = patient.Name;
            Surname = patient.Surname;
            IdentityNumber = patient.IdentityNumber;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
            yield return IdentityNumber;
        }
    }
}