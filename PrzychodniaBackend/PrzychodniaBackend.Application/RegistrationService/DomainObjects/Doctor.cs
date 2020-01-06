using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects
{
    public class Doctor : ValueObject
    {
        public long Id { get; }
        public string? Name { get; }
        public string? Surname { get; }

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