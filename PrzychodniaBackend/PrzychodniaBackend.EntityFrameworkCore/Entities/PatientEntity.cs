namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class PatientEntity
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string IdentityNumber { get; set; }

        internal PatientEntity(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }
    }
}
