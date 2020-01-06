using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Api.Controllers.LaboratoryControllerDtos;
using PrzychodniaBackend.Application.LaboratoryService;
using PrzychodniaBackend.Application.LaboratoryService.DomainObjects;
using PrzychodniaBackend.Application.LaboratoryService.DomainObjects.Inputs;

namespace PrzychodniaBackend.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService _laboratoryService;

        public LaboratoryController(ILaboratoryService laboratoryService)
        {
            _laboratoryService = laboratoryService;
        }

        [HttpGet]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<LabTestOrder>), StatusCodes.Status200OK)]
        public IActionResult GetAllLabTestOrders()
        {
            return Ok(_laboratoryService.GetAllLabTestOrders());
        }

        [HttpGet]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(LabTestOrder), StatusCodes.Status200OK)]
        public IActionResult GetLabTestOrder(long id)
        {
            return Ok(_laboratoryService.GetLabTestOrder(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(LabTestResult), StatusCodes.Status200OK)]
        public IActionResult FinishLabTest(LabTestResultDto result)
        {
            return Ok(_laboratoryService.FinishLabTest(new NewLabTestResult(result.LabTestOrderId,
                result.Description, Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier).Value))));
        }

        [HttpPost]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(IEnumerable<LabTestResult>), StatusCodes.Status200OK)]
        public IActionResult GetAllLabResult()
        {
            return Ok(_laboratoryService.GetAllLabResults());
        }
    }
}