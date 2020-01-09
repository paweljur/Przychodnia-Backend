using System.Collections.Generic;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects
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