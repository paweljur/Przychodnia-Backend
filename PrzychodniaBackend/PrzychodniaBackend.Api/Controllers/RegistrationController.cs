using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.RegistrationControllerDtos;
using PrzychodniaBackend.Application.RegistrationService;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects.Inputs;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,registrant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public IActionResult GetAllAppointments()
        {
            return Ok(_registrationService.GetAllAppointments());
        }

        [HttpPost]
        [Authorize(Roles = "admin,registrant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult MakeAppointment(NewAppointmentDto appointment)
        {
            if (appointment.PatientId is null || appointment.AppointmentDate is null || appointment.DoctorId is null)
            {
                return BadRequest("Patient, doctor and date are required for an appointment");
            }

            _registrationService.MakeAnAppointment(new NewAppointment(appointment.PatientId.Value,
                appointment.DoctorId.Value, appointment.AppointmentDate.Value));
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "admin,registrant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public IActionResult GetAllPatients()
        {
            return Ok(_registrationService.GetAllPatients());
        }

        [HttpGet]
        [Authorize(Roles = "admin,registrant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<Doctor>), StatusCodes.Status200OK)]
        public IActionResult GetAllDoctors()
        {
            return Ok(_registrationService.GetAllDoctors());
        }

        [HttpPost]
        [Authorize(Roles = "admin,registrant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        public IActionResult RegisterPatient(NewPatientDto patient)
        {
            if (patient.IdentityNumber is null)
            {
                return BadRequest(new ApiError("No identity number"));
            }

            Patient createdPatient =
                _registrationService.RegisterPatient(
                    new NewPatient(patient.IdentityNumber, patient.Name, patient.Surname));

            return Ok(createdPatient);
        }
    }
}