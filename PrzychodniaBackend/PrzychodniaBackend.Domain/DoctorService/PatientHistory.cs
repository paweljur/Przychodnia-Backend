using System.Collections.Generic;
using PrzychodniaBackend.Application.DoctorService.Dto;
using PrzychodniaBackend.Application.Laboratory;

namespace PrzychodniaBackend.Application.DoctorService
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