using System.Collections.Generic;
using PrzychodniaBackend.Application.LaboratoryService.Dto;

namespace PrzychodniaBackend.Application.DoctorService.Dto
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