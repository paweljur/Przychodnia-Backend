namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class PatientEntity
    {
        public long Id { get; private set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string IdentityNumber { get; set; }

        public PatientEntity(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private PatientEntity()
        {
        }
    }
}