using System;
using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        void CreateAppointment(PatientEntity patient, UserEntity doctor, DateTimeOffset appointmentDate);
        IEnumerable<AppointmentEntity> GetAll();
        IEnumerable<AppointmentEntity> GetAllByDoctor(long doctorsId);
        AppointmentEntity? Get(long appointmentId);
        void Save();
    }
}