using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<LabTestOrderEntity> GetAll()
        {
            return _context.LabTestOrders.Include(o => o.Doctor).Include(o => o.Patient).AsNoTracking().ToList();
        }
    }
}
