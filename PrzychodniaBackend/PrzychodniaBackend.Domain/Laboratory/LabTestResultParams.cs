namespace PrzychodniaBackend.Application.Laboratory
{
    public class LabTestResultParams
    {
        public long LabTestOrderId { get; set; }
        public string? Description { get; set; }
        public long LaborantId { get; set; }

        public LabTestResultParams(long labTestOrderId, string? description, long laborantId)
        {
            LabTestOrderId = labTestOrderId;
            Description = description;
            LaborantId = laborantId;
        }
    }
}