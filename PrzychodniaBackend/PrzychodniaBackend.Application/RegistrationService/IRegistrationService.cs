using System.Collections.Generic;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs;

namespace PrzychodniaBackend.Application.RegistrationService
{
    public interface IRegistrationService
    {
        Patient RegisterPatient(NewPatient patient);
        IEnumerable<Patient> GetAllPatients();
        void MakeAnAppointment(NewAppointment newAppointment);
        IEnumerable<Appointment> GetAllAppointments();
        IEnumerable<Doctor> GetAllDoctors();
    }
}