using System.Collections.Generic;
using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    class LabTestOrderRepository : ILabTestOrderRepository
    {
        private readonly AppContext _context;

        public LabTestOrderRepository(AppContext context)
        {
            _context = context;
        }

        public void Add(IEnumerable<LabTestOrderEntity> labTestOrders)
        {
            _context.LabTestOrders.AddRange(labTestOrders);
            _context.SaveChanges();
        }
    }
}
