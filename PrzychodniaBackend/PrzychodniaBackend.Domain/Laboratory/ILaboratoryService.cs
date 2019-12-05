using System.Collections.Generic;

namespace PrzychodniaBackend.Application.Laboratory
{
    public interface ILaboratoryService
    {
        IEnumerable<LabTestOrder> GetAllLabTestOrders();
        LabTestOrder GetLabTestOrder(long id);
        LabTestResult FinishLabTest(LabTestResultParams labTestResultParams);
    }
}
