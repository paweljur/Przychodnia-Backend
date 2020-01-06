using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.LaboratoryService.DomainObjects
{
    public class Laborant
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        internal Laborant(UserEntity user)
        {
            Id = user.Id;
            Surname = user.Surname;
            Name = user.Name;
        }
    }
}