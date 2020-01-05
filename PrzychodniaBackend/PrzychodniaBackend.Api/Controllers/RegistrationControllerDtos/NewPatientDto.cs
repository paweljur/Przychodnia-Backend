using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.RegistrationControllerDtos
{
    public class NewPatientDto : ValueObject
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdentityNumber { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Name;
            yield return Surname;
            yield return IdentityNumber;
        }
    }
}