using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.LaboratoryService.Dto
{
    public class LabTestOrder
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? DoctorsNote { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        internal LabTestOrder(LabTestOrderEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            DoctorsNote = entity.DoctorsNote;
            Patient = new Patient(entity.Patient);
            Doctor = new Doctor(entity.Doctor);
        }
    }
}