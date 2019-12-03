using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;

namespace PrzychodniaBackend.Application.Laboratory
{
    internal class LaboratoryService : ILaboratoryService
    {
        private readonly ILabTestOrderRepository _labTestOrderRepository;

        public LaboratoryService(ILabTestOrderRepository labTestOrderRepository)
        {
            _labTestOrderRepository = labTestOrderRepository;
        }

        public IEnumerable<LabTestOrder> GetAllLabTestOrders()
        {
            return _labTestOrderRepository.GetAll().Select(o => new LabTestOrder(o));
        }
    }
}