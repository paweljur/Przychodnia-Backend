using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.DoctorControllerDtos
{
    public class VisitDetailsDto : ValueObject
    {
        public long AppointmentId { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        public IEnumerable<LabTestOrderDto>? LabTestOrders { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return AppointmentId;
            yield return Description;
            yield return Diagnosis;
            yield return LabTestOrders;
        }
    }
}