using System.Collections.Generic;
using PrzychodniaBackend.Application.LaboratoryService.Dto;
using PrzychodniaBackend.Shared;

namespace PrzychodniaBackend.Application.DoctorService.DomainObjects
{
    public class PatientHistory : ValueObject
    {
        public IEnumerable<Visit> Visits { get; set; }
        public IEnumerable<LabTestResult> TestResults { get; set; }

        public PatientHistory(IEnumerable<Visit> visits, IEnumerable<LabTestResult> testResults)
        {
            Visits = visits;
            TestResults = testResults;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Visits;
            yield return TestResults;
        }
    }
}