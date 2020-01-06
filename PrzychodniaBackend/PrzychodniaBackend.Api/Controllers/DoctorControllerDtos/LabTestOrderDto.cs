using System.Collections.Generic;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Api.Controllers.DoctorControllerDtos
{
    public class LabTestOrderDto : ValueObject
    {
        public string? Name { get; set; }
        public string? DoctorsNote { get; set; }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Name;
            yield return DoctorsNote;
        }
    }
}