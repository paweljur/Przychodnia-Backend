using System.Collections.Generic;
using PrzychodniaBackend.Application.LaboratoryService.DomainObjects;
using PrzychodniaBackend.Application.LaboratoryService.DomainObjects.Inputs;

namespace PrzychodniaBackend.Application.LaboratoryService
{
    public interface ILaboratoryService
    {
        IEnumerable<LabTestOrder> GetAllLabTestOrders();
        LabTestOrder GetLabTestOrder(long id);
        LabTestResult FinishLabTest(NewLabTestResult newLabTestResult);
        IEnumerable<LabTestResult> GetAllLabResults();
    }
}