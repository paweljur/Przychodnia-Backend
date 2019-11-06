using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.PatientRepo;

namespace PrzychodniaBackend.Application.RegistrationService
{
    internal class RegistrationService : IRegistrationService
    {
        private readonly IPatientRepository _patientRepository;

        public RegistrationService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public void AddNewPatient(NewPatient patient)
        {
            _patientRepository.Add(patient.IdentityNumber, patient.Name, patient.Surname);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll()
                .Select(patient => new Patient(patient.IdentityNumber, patient.Name, patient.Surname));
        }
    }
}
