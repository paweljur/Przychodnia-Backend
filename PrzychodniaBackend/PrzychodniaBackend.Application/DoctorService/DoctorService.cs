using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.DoctorService.Dto;
using PrzychodniaBackend.Application.LaboratoryService.Dto;
using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo;

namespace PrzychodniaBackend.Application.DoctorService
{
    internal class DoctorService : IDoctorService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly ILabTestOrderRepository _labTestOrderRepository;
        private readonly ILabTestResultRepository _labTestResultRepository;

        public DoctorService(IAppointmentRepository appointmentRepository, IVisitRepository visitRepository, ILabTestOrderRepository labTestOrderRepository, ILabTestResultRepository labTestResultRepository)
        {
            _appointmentRepository = appointmentRepository;
            _visitRepository = visitRepository;
            _labTestOrderRepository = labTestOrderRepository;
            _labTestResultRepository = labTestResultRepository;
        }

        public IEnumerable<Appointment> GetDoctorsAppointments(long doctorId)
        {
            return _appointmentRepository.GetAllByDoctor(doctorId).Select(a => new Appointment(a));
        }

        public void CancelAppointment(long appointmentId)
        {
            AppointmentEntity? appointment = _appointmentRepository.Get(appointmentId);
            appointment.IsCancelled = true;
            _appointmentRepository.Save();
        }

        public void FinishAppointment(VisitDetails visitDetails)
        {
            AppointmentEntity? appointment = _appointmentRepository.Get(visitDetails.AppointmentId);
            appointment.IsAttended = true;
            _visitRepository.Add(appointment, visitDetails.Description, visitDetails.Diagnosis);
            _labTestOrderRepository.Add(visitDetails.LabTestOrders.Select(o =>
                new LabTestOrderEntity(o.Name, o.DoctorsNote, appointment.Patient, appointment.Doctor)));
        }

        public IEnumerable<Visit> GetPastVisits(long doctorId)
        {
            return _visitRepository.GetAllByDoctor(doctorId).Select(v => new Visit(v));
        }

        public PatientHistory GetPatientHistory(long patientId)
        {
            IEnumerable<Visit> visits = _visitRepository.GetAllByPatient(patientId).Select(v => new Visit(v));
            IEnumerable<LabTestResult> testResults = _labTestResultRepository.GetAllByPatient(patientId).Select(r => new LabTestResult(r));

            return new PatientHistory(visits, testResults);
        }
    }
}