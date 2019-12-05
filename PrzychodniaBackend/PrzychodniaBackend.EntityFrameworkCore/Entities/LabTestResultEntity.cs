namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class LabTestResultEntity
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public LabTestOrderEntity LabTestOrder { get; set; }

        public LabTestResultEntity(string? description, LabTestOrderEntity labTestOrder)
        {
            Description = description;
            LabTestOrder = labTestOrder;
        }

        private LabTestResultEntity(string? description)
        {
            Description = description;
        }
    }
}
