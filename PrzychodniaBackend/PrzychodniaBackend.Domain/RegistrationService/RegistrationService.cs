using System;
using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.RegistrationService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.PatientRepo;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo;

namespace PrzychodniaBackend.Application.RegistrationService
{
    internal class RegistrationService : IRegistrationService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public RegistrationService(IPatientRepository patientRepository, IUserRepository userRepository, IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }

        public Patient AddNewPatient(NewPatient patient)
        {
            return new Patient(_patientRepository.Add(patient.IdentityNumber, patient.Name, patient.Surname));
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll().Select(patient => new Patient(patient));
        }

        public void MakeAnAppointment(NewAppointment newAppointment)
        {
            PatientEntity? patient = _patientRepository.GetBy(newAppointment.PatientId);
            UserEntity? doctor = _userRepository.GetDoctorBy(newAppointment.DoctorId);
            
            if (patient is null || doctor is null)
            {
                throw new ApplicationException(
                    "Unable to create appointment, because patient or doctor does not exist");
            }

            _appointmentRepository.CreateAppointment(patient, doctor, newAppointment.AppointmentDate);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll().Select(a => new Appointment(a));
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _userRepository.GetAllDoctors().Select(user => new Doctor(user));
        }
    }
}
