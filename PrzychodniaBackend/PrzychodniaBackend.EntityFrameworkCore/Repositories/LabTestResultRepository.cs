using PrzychodniaBackend.EntityFrameworkCore.Entities;

namespace PrzychodniaBackend.EntityFrameworkCore.Repositories
{
    internal class LabTestResultRepository : ILabTestResultRepository
    {
        private readonly AppContext _context;

        public LabTestResultRepository(AppContext context)
        {
            _context = context;
        }

        public void Add(LabTestResultEntity labTestResultEntity)
        {
            _context.LabTestResults.Add(labTestResultEntity);
            _context.SaveChanges();
        }
    }
}