using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Application.DoctorService;
using PrzychodniaBackend.Application.DoctorService.Dto;
using PrzychodniaBackend.Application.RegistrationService.Dto;

namespace PrzychodniaBackend.Api.Controllers.DoctorCon
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorsService;

        public DoctorController(IDoctorService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        [HttpGet("getAllAppointments")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public IActionResult GetAllAppointments()
        {
            return Ok(_doctorsService.GetDoctorsAppointments(
                Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpPatch("cancelAppointment")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult CancelAppointment(long appointmentId)
        {
            _doctorsService.CancelAppointment(appointmentId);
            return NoContent();
        }

        [HttpPost("finishAppointment")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
        public IActionResult FinishAppointment(VisitDetailsDto visitDetails)
        {
            _doctorsService.FinishAppointment(new VisitDetails(visitDetails.AppointmentId, visitDetails.Description,
                visitDetails.Diagnosis,
                visitDetails.LabTestOrders.Select(o => new LabTestOrder(o.Name, o.DoctorsNote))));
            return NoContent();
        }

        [HttpGet("getPastVisits")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<Visit>), StatusCodes.Status200OK)]
        public IActionResult GetPastVisits()
        {
            return Ok(_doctorsService.GetPastVisits(Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }

        [HttpGet("getPatientHistory")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(PatientHistory), StatusCodes.Status200OK)]
        public IActionResult GetPatientHistory(long patientId)
        {
            return Ok(_doctorsService.GetPatientHistory(patientId));
        }
    }
}
