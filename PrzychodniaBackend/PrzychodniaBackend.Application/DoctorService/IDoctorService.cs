using System.Collections.Generic;
using PrzychodniaBackend.Application.DoctorService.DomainObjects;
using PrzychodniaBackend.Application.DoctorService.DomainObjects.Inputs;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects;

namespace PrzychodniaBackend.Application.DoctorService
{
    public interface IDoctorService
    {
        IEnumerable<Appointment> GetDoctorsAppointments(long doctorId);
        void CancelAppointment(long appointmentId);
        void FinishAppointment(VisitDetails visitDetails);
        IEnumerable<Visit> GetPastVisits(long doctorId);
        PatientHistory GetPatientHistory(long patientId);
    }
}