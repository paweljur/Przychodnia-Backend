namespace PrzychodniaBackend.EntityFrameworkCore.Entities
{
    public class LabTestResultEntity
    {
        public long Id { get; private set; }
        public string? Description { get; set; }
        public LabTestOrderEntity LabTestOrder { get; set; }
        public UserEntity Laborant { get; set; }

        public LabTestResultEntity(string? description, LabTestOrderEntity labTestOrder, UserEntity laborant)
        {
            Description = description;
            LabTestOrder = labTestOrder;
            Laborant = laborant;
        }

        #nullable disable
        // Required for proper ef core foreign key mapping
        private LabTestResultEntity()
        {
        }
    }
}