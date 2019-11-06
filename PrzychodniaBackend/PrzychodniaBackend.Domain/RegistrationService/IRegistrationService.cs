using System.Collections.Generic;
using PrzychodniaBackend.Application.RegistrationService.Dto;

namespace PrzychodniaBackend.Application.RegistrationService
{
    public interface IRegistrationService
    {
        void AddNewPatient(NewPatient patient);
        IEnumerable<Patient> GetAllPatients();
    }
}
