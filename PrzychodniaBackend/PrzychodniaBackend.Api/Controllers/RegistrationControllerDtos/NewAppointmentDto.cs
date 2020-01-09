using System;

namespace PrzychodniaBackend.Api.Controllers.RegistrationControllerDtos
{
    public class NewAppointmentDto
    {
        public long? PatientId { get; set; }
        public long? DoctorId { get; set; }
        public DateTimeOffset? AppointmentDate { get; set; }
    }
}