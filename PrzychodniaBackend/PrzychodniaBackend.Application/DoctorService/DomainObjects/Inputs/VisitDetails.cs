using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects.Inputs
{
    public class VisitDetails : ValueObject
    {
        public long AppointmentId { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        public IEnumerable<LabTestOrder> LabTestOrders { get; set; }

        public VisitDetails(long appointmentId, string? description, string? diagnosis, IEnumerable<LabTestOrder> labTestOrders)
        {
            AppointmentId = appointmentId;
            Description = description;
            Diagnosis = diagnosis;
            LabTestOrders = labTestOrders;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return AppointmentId;
            yield return Description;
            yield return Diagnosis;
            yield return LabTestOrders;
        }
    }
}