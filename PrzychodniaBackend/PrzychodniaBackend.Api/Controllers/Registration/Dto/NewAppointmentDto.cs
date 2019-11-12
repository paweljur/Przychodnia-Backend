using System;
using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.Registration.Dto
{
    public class NewAppointmentDto : ValueObject
    {
        public long? PatientId { get; set; }
        public long? DoctorId { get; set; }
        public DateTimeOffset? AppointmentDate { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return PatientId;
            yield return DoctorId;
            yield return AppointmentDate;
        }
    }
}