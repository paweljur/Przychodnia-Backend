namespace PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs
{
    public class NewPatient
    {
        public string? Name { get; }
        public string? Surname { get; }
        public string IdentityNumber { get; }

        public NewPatient(string identityNumber, string? name, string? surname)
        {
            IdentityNumber = identityNumber;
            Name = name;
            Surname = surname;
        }
    }
}