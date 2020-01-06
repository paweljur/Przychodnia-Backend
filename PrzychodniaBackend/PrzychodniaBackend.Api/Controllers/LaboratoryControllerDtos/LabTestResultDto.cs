using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.LaboratoryControllerDtos
{
    public class LabTestResultDto : ValueObject
    {
        public string? Description { get; set; }
        public long LabTestOrderId { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Description;
            yield return LabTestOrderId;
        }
    }
}