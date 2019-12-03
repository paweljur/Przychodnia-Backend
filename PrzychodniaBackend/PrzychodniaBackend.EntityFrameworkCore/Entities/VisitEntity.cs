namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class VisitEntity
    {
        public long Id { get; set; }
        public AppointmentEntity Appointment { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        
        internal VisitEntity(AppointmentEntity appointment, string? description, string? diagnosis)
        {
            Appointment = appointment;
            Description = description;
            Diagnosis = diagnosis;
        }

        private VisitEntity(string? description, string? diagnosis)
        {
            Description = description;
            Diagnosis = diagnosis;
        }
    }
}