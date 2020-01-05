namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class VisitEntity
    {
        public long Id { get; private set; }
        public AppointmentEntity Appointment { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        
        public VisitEntity(AppointmentEntity appointment, string? description, string? diagnosis)
        {
            Appointment = appointment;
            Description = description;
            Diagnosis = diagnosis;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private VisitEntity()
        {
        }
    }
}