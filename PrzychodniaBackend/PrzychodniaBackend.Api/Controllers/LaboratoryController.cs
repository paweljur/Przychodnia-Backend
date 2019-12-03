using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzychodniaBackend.Application.Laboratory;

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

        [HttpGet("GetAllLabTestOrders")]
        [Authorize(Roles = "admin,laborant")]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(IEnumerable<LabTestOrder>), StatusCodes.Status200OK)]
        public IActionResult GetAllLabTestOrders()
        {
            return Ok(_laboratoryService.GetAllLabTestOrders());
        }
    }
}
