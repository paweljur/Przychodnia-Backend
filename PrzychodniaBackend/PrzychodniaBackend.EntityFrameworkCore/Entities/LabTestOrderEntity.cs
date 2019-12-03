namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class LabTestOrderEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? DoctorsNote { get; set; }
        public PatientEntity Patient { get; set; }
        public UserEntity Doctor { get; set; }

        public LabTestOrderEntity(string name, string? doctorsNote, PatientEntity patient, UserEntity doctor)
        {
            Name = name;
            DoctorsNote = doctorsNote;
            Patient = patient;
            Doctor = doctor;
        }

        private LabTestOrderEntity(string name, string? doctorsNote)
        {
            Name = name;
            DoctorsNote = doctorsNote;
        }
    }
}
