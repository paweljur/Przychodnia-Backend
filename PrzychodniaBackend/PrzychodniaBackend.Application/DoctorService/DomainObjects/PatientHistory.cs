using System.Collections.Generic;
using PrzychodniaBackend.Application.LaboratoryService.DomainObjects;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects
{
    public class PatientHistory
    {
        public IEnumerable<Visit> Visits { get; set; }
        public IEnumerable<LabTestResult> TestResults { get; set; }

        public PatientHistory(IEnumerable<Visit> visits, IEnumerable<LabTestResult> testResults)
        {
            Visits = visits;
            TestResults = testResults;
        }
    }
}