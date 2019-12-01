namespace PrzychodniaBackend.Application.DoctorService.Dto
{
    public class VisitDetails
    {
        public long AppointmentId { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }

        public VisitDetails(long appointmentId, string? description, string? diagnosis)
        {
            AppointmentId = appointmentId;
            Description = description;
            Diagnosis = diagnosis;
        }
    }
}