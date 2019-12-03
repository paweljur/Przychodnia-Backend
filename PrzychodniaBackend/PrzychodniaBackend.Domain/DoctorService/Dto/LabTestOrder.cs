namespace PrzychodniaBackend.Application.DoctorService.Dto
{
    public class LabTestOrder
    {
        public string Name { get; set; }
        public string? DoctorsNote { get; set; }

        public LabTestOrder(string name, string doctorsNote)
        {
            Name = name;
            DoctorsNote = doctorsNote;
        }
    }
}