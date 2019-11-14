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

        [HttpGet("appointment")]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public IActionResult GetAllAppointments()
        {
            return Ok(_registrationService.GetAllAppointments());
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
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]

        public IActionResult GetAllPatients()
        {
            return Ok(_registrationService.GetAllPatients());
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        public IActionResult AddNewPatient(NewPatientDto patient)
        {
            if (patient.IdentityNumber is null)
            {
                return BadRequest(new ApiError("No identity number"));
            }

            Patient createdPatient =
                _registrationService.AddNewPatient(
                    new NewPatient(patient.IdentityNumber, patient.Name, patient.Surname));

            return Ok(createdPatient);
        }
    }
}