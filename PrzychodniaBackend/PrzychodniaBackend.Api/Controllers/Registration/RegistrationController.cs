using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.Registration.Dto;
using PrzychodniaBackend.Application.RegistrationService;
using PrzychodniaBackend.Application.RegistrationService.Dto;

namespace PrzychodniaBackend.Api.Controllers.Registration
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost("appointment")]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult MakeAppointment(NewAppointmentDto appointment)
        {
            if (appointment.PatientId is null || appointment.AppointmentDate is null || appointment.DoctorId is null)
            {
                return BadRequest("Patient, doctor and date are required for an appointment");
            }

            _registrationService.MakeAnAppointment(new NewAppointment(appointment.PatientId.Value, appointment.DoctorId.Value, appointment.AppointmentDate.Value));
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<PatientDto>), StatusCodes.Status200OK)]

        public IActionResult GetAllPatients()
        {
            IEnumerable<Patient> patients = _registrationService.GetAllPatients();

            return Ok(patients.Select(patient =>
                new PatientDto(patient.IdentityNumber, patient.Name, patient.Surname)));
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult AddNewPatient(NewPatientDto patient)
        {
            if (patient.IdentityNumber is null)
            {
                return BadRequest("No identity number");
            }
            _registrationService.AddNewPatient(new NewPatient(patient.IdentityNumber, patient.Name, patient.Surname));

            return NoContent();
        }
    }
}