using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.DTO;
using Services;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeBenefitsCalculator.Controllers
{
    [Route("v1/benefits")]
    public class BenefitsV1Controller : Controller
    {
        private readonly IEmployeeBenefitsService _employeeBenefitsService;
        private readonly ILogger _logger;

        public BenefitsV1Controller(IEmployeeBenefitsService benefitsService, ILogger<BenefitsV1Controller> logger)
        {
            _employeeBenefitsService = benefitsService;
            _logger = logger;
        }

        [Route("cost")]
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(BenefitDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculateCost([FromBody] EmployeeDTO body) 
        {
            if (body == null || String.IsNullOrEmpty(body.FirstName) || String.IsNullOrEmpty(body.LastName)) 
            {
                return BadRequest();
            }

            try
            {
                var response = await _employeeBenefitsService.CalculateBenefitsCost(body);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{nameof(BenefitsV1Controller)} - Error Calculating Benefits Cost!");
                throw ex;
            }
        }
    }
}
