namespace PrzychodniaBackend.Application.Laboratory
{
    public class LabTestResultParams
    {
        public long LabTestOrderId { get; set; }
        public string? Description { get; set; }

        public LabTestResultParams(long labTestOrderId, string? description)
        {
            LabTestOrderId = labTestOrderId;
            Description = description;
        }
    }
}