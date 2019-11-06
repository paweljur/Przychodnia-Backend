namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class PatientEntity
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public string IdentityNumber { get; private set; }

        internal PatientEntity(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }
    }
}
