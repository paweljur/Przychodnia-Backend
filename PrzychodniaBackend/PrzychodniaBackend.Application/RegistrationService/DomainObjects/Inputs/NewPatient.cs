using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs
{
    public class NewPatient : ValueObject
    {
        public string? Name { get; }
        public string? Surname { get; }
        public string IdentityNumber { get; }

        public NewPatient(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Name;
            yield return Surname;
            yield return IdentityNumber;
        }
    }
}