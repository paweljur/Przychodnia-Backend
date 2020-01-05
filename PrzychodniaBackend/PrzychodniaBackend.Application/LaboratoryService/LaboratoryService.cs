using System.Collections.Generic;
using System.Linq;
using PrzychodniaBackend.Application.LaboratoryService.Dto;
using PrzychodniaBackend.EntityFrameworkCore.Entities;
using PrzychodniaBackend.EntityFrameworkCore.Repositories;
using PrzychodniaBackend.EntityFrameworkCore.Repositories.UserRepo;

namespace PrzychodniaBackend.Application.LaboratoryService
{
    internal class LaboratoryService : ILaboratoryService
    {
        private readonly ILabTestOrderRepository _labTestOrderRepository;
        private readonly ILabTestResultRepository _labTestResultRepository;
        private readonly IUserRepository _userRepository;

        public LaboratoryService(ILabTestOrderRepository labTestOrderRepository,
            ILabTestResultRepository labTestResultRepository, IUserRepository userRepository)
        {
            _labTestOrderRepository = labTestOrderRepository;
            _labTestResultRepository = labTestResultRepository;
            _userRepository = userRepository;
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
            UserEntity laborant = _userRepository.GetLaborantBy(labTestResultParams.LaborantId);
            order.IsExecuted = true;
            var result = new LabTestResultEntity(labTestResultParams.Description, order, laborant);
            _labTestResultRepository.Add(result);

            return new LabTestResult(result);
        }

        public IEnumerable<LabTestResult> GetAllLabResults()
        {
            return _labTestResultRepository.GetAll().Select(r => new LabTestResult(r));
        }
    }
}