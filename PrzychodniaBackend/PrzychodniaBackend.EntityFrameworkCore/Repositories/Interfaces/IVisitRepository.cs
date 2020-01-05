using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        VisitEntity Add(AppointmentEntity appointment, string? description, string? diagnosis);
        IEnumerable<VisitEntity> GetAllByDoctor(long doctorId);
        IEnumerable<VisitEntity> GetAllByPatient(long patientId);
    }
}