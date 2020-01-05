using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories.Interfaces
{
    public interface ILabTestOrderRepository
    {
        void Add(IEnumerable<LabTestOrderEntity> labTestOrders);
        IEnumerable<LabTestOrderEntity> GetAll();
        LabTestOrderEntity Get(long id);
    }
}