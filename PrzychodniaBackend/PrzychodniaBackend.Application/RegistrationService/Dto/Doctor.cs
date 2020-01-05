using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.Dto
{
    public class Doctor : ValueObject
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        internal Doctor(UserEntity user)
        {
            Id = user.Id;
            Surname = user.Surname;
            Name = user.Name;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
        }
    }
}