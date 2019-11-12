using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class Doctor : ValueObject
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public Doctor(long id, string? name, string? surname)
        {
            Id = id;
            Surname = surname;
            Name = name;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
        }
    }
}