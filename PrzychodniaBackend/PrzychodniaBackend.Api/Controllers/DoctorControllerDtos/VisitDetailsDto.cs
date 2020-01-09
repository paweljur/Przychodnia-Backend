using System.Collections.Generic;

namespace PrzychodniaBackend.Api.Controllers.DoctorControllerDtos
{
    public class VisitDetailsDto
    {
        public long AppointmentId { get; set; }
        public string? Description { get; set; }
        public string? Diagnosis { get; set; }
        public IEnumerable<LabTestOrderDto>? LabTestOrders { get; set; }
    }
}