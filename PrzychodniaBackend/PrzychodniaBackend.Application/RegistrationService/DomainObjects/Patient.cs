using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects
{
    public class Patient
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
    }
}