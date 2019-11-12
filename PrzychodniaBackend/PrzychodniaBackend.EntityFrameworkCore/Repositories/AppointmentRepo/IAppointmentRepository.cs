using System;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.AppointmentRepo
{
    public interface IAppointmentRepository
    {
        void CreateAppointment(PatientEntity patient, User doctor, DateTimeOffset appointmentDate);
    }
}
