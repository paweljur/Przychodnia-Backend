using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects
{
    public class LabTestOrder : ValueObject
    {
        public string Name { get; set; }
        public string? DoctorsNote { get; set; }

        public LabTestOrder(string name, string doctorsNote)
        {
            Name = name;
            DoctorsNote = doctorsNote;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Name;
            yield return DoctorsNote;
        }
    }
}