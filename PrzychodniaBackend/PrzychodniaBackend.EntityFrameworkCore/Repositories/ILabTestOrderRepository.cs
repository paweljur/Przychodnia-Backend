using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    public interface ILabTestOrderRepository
    {
        void Add(IEnumerable<LabTestOrderEntity> labTestOrders);
        IEnumerable<LabTestOrderEntity> GetAll();
    }
}
