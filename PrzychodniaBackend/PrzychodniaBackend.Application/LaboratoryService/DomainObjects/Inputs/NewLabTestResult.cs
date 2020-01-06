namespace PrzychodniaBackend.Application.LaboratoryService.DomainObjects.Inputs
{
    public class NewLabTestResult
    {
        public long LabTestOrderId { get; set; }
        public string? Description { get; set; }
        public long LaborantId { get; set; }

        public NewLabTestResult(long labTestOrderId, string? description, long laborantId)
        {
            LabTestOrderId = labTestOrderId;
            Description = description;
            LaborantId = laborantId;
        }
    }
}