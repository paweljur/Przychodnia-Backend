using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;

namespace PrzychodniaBackend.Application.Laboratory
{
    internal class LaboratoryService : ILaboratoryService
    {
        private readonly ILabTestOrderRepository _labTestOrderRepository;
        private readonly ILabTestResultRepository _labTestResultRepository;

        public LaboratoryService(ILabTestOrderRepository labTestOrderRepository, ILabTestResultRepository labTestResultRepository)
        {
            _labTestOrderRepository = labTestOrderRepository;
            _labTestResultRepository = labTestResultRepository;
        }

        public IEnumerable<LabTestOrder> GetAllLabTestOrders()
        {
            return _labTestOrderRepository.GetAll().Select(o => new LabTestOrder(o));
        }

        public LabTestOrder GetLabTestOrder(long id)
        {
            return new LabTestOrder(_labTestOrderRepository.Get(id));
        }

        public LabTestResult FinishLabTest(LabTestResultParams labTestResultParams)
        {
            LabTestOrderEntity order = _labTestOrderRepository.Get(labTestResultParams.LabTestOrderId);
            order.IsExecuted = true;
            var result = new LabTestResultEntity(labTestResultParams.Description, order);
            _labTestResultRepository.Add(result);

            return new LabTestResult(result);
        }
    }
}