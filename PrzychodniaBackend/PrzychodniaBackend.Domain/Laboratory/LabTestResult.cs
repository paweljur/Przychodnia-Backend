using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.Application.Laboratory
{
    public class LabTestResult
    {
        public long Id { get; set; }
        public string? Description { get; set; }

        public LabTestResult(LabTestResultEntity result)
        {
            Id = result.Id;
            Description = result.Description;
        }
    }
}