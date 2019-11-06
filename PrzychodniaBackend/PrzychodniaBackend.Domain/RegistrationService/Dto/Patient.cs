using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class Patient : ValueObject
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string IdentityNumber { get; set; }

        public Patient(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
            yield return IdentityNumber;
        }
    }
}