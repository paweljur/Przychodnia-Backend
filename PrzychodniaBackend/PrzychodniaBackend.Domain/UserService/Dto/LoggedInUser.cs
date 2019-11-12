using System;
using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.UserService.Dto
{
    public class LoggedInUser : ValueObject
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }

        public LoggedInUser(string? name, string? surname)
        {
            Id = Guid.Empty;
            Name = name;
            Surname = surname;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
            yield return Surname;
        }
    }
}