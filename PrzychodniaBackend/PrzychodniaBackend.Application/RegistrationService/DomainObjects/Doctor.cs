using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects
{
    public class Doctor
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
    }
}