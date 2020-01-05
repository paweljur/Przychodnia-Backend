using System.Collections.Generic;
using PrzychodniaBackend.Application.LaboratoryService.Dto;

namespace PrzychodniaBackend.Application.LaboratoryService
{
    public interface ILaboratoryService
    {
        IEnumerable<LabTestOrder> GetAllLabTestOrders();
        LabTestOrder GetLabTestOrder(long id);
        LabTestResult FinishLabTest(LabTestResultParams labTestResultParams);
        IEnumerable<LabTestResult> GetAllLabResults();
    }
}