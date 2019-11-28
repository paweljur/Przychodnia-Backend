using System;
using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo
{
    public interface IAppointmentRepository
    {
        void CreateAppointment(PatientEntity patient, UserEntity doctor, DateTimeOffset appointmentDate);
        IEnumerable<AppointmentEntity> GetAll();
        IEnumerable<AppointmentEntity> GetAllByDoctor(long doctorsId);
    }
}
