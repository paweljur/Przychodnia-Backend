using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    public interface IVisitRepository
    {
        VisitEntity Add(AppointmentEntity appointment, string? description, string? diagnosis);
    }
}
