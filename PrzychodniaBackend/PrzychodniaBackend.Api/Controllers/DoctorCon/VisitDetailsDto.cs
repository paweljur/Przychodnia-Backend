namespace PrzychodniaBackend.Api.Controllers.DoctorCon
{
    public class VisitDetailsDto
    {
        public long AppointmentId { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
    }
}