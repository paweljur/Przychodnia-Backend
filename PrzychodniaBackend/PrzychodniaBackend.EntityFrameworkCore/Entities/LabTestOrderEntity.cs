namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class LabTestOrderEntity
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public string? DoctorsNote { get; set; }
        public PatientEntity Patient { get; set; }
        public UserEntity Doctor { get; set; }
        public bool IsExecuted { get; set; }

        public LabTestOrderEntity(string name, string? doctorsNote, PatientEntity patient, UserEntity doctor)
        {
            Name = name;
            DoctorsNote = doctorsNote;
            Patient = patient;
            Doctor = doctor;
            IsExecuted = false;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private LabTestOrderEntity()
        {
        }
    }
}