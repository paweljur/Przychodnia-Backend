using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.DoctorControllerDtos;
using PrzychodniaBackend.Application.DoctorService;
using PrzychodniaBackend.Application.DoctorService.DomainObjects;
using PrzychodniaBackend.Application.DoctorService.DomainObjects.Inputs;
using PrzychodniaBackend.Application.RegistrationService.DomainObjects;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorsService;

        public DoctorController(IDoctorService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public IActionResult GetAllAppointments()
        {
            return Ok(_doctorsService.GetDoctorsAppointments(
                Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPatch]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult CancelAppointment(long appointmentId)
        {
            _doctorsService.CancelAppointment(appointmentId);
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ApiError), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult FinishAppointment(VisitDetailsDto visitDetails)
        {
            if (visitDetails.LabTestOrders is {} && visitDetails.LabTestOrders.Any(o => o.Name is null))
            {
                return BadRequest(new ApiError("Lab test needs a name"));
            }

            _doctorsService.FinishAppointment(new VisitDetails(visitDetails.AppointmentId,
                visitDetails.Description,
                visitDetails.Diagnosis,
                visitDetails.LabTestOrders.Select(o => new LabTestOrder(o.Name!, o.DoctorsNote!))));
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<Visit>), StatusCodes.Status200OK)]
        public IActionResult GetPastVisits()
        {
            return Ok(_doctorsService.GetPastVisits(Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpGet]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(PatientHistory), StatusCodes.Status200OK)]
        public IActionResult GetPatientHistory(long patientId)
        {
            return Ok(_doctorsService.GetPatientHistory(patientId));
        }
    }
}