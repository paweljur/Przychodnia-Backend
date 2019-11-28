using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Application.DoctorService;
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

        [HttpGet("appointment")]
        [Authorize(Roles = "admin,doctor")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Appointment>), StatusCodes.Status200OK)]
        public IActionResult GetAllAppointments()
        {
            return Ok(_doctorsService.GetDoctorsAppointments(
                Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value)));
        }
    }
}
