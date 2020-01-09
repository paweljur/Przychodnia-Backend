using System.Collections.Generic;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects.Inputs
{
    public class VisitDetails
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
    }
}