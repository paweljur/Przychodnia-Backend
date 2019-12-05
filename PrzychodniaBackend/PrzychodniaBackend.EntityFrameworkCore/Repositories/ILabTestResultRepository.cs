using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    public interface ILabTestResultRepository
    {
        void Add(LabTestResultEntity labTestResultEntity);
    }
}
