using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.LaboratoryControllerDtos;
using PrzychodniaBackend.Application.LaboratoryService;
using PrzychodniaBackend.Application.LaboratoryService.Dto;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/laboratory")]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        [HttpGet("getAllLabTestOrders")]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<LabTestOrder>), StatusCodes.Status200OK)]
        public IActionResult GetAllLabTestOrders()
        {
            return Ok(_laboratoryService.GetAllLabTestOrders());
        }

        [HttpGet("getLabTestOrder")]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(LabTestOrder), StatusCodes.Status200OK)]
        public IActionResult GetLabTestOrder(long id)
        {
            return Ok(_laboratoryService.GetLabTestOrder(id));
        }

        [HttpPost("finishLabTest")]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(LabTestResult), StatusCodes.Status200OK)]
        public IActionResult FinishLabTest(LabTestResultDto result)
        {
            return Ok(_laboratoryService.FinishLabTest(new LabTestResultParams(result.LabTestOrderId,
                result.Description, Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value))));
        }

        [HttpPost("getAllLabResult")]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<LabTestResult>), StatusCodes.Status200OK)]
        public IActionResult GetAllLabResult()
        {
            return Ok(_laboratoryService.GetAllLabResults());
        }
    }
}