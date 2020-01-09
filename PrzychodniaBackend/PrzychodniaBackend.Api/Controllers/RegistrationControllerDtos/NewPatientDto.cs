namespace PrzychodniaBackend.Api.Controllers.RegistrationControllerDtos
{
    public class NewPatientDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? IdentityNumber { get; set; }
    }
}