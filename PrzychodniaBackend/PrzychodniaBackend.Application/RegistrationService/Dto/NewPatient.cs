using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class NewPatient : ValueObject
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string IdentityNumber { get; set; }

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