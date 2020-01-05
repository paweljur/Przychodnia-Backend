using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.Laboratory
{
    public class LabTestResult
    {
        public long Id { get; set; }
        public string? Result { get; set; }
        public string? TestName { get; set; }
        public Patient Patient { get; set; }
        public Laborant Laborant { get; set; }

        public LabTestResult(LabTestResultEntity result)
        {
            Id = result.Id;
            Result = result.Description;
            TestName = result.LabTestOrder.Name;
            Patient = new Patient(result.LabTestOrder.Patient);
            Laborant = new Laborant(result.Laborant);
        }
    }
}