using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using System;
using System.Threading.Tasks;

namespace EmployeeBenefitsCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeBenefitsController : ControllerBase
    {
        private readonly IEmployeeBenefitsService _employeeBenefitsService;
        private readonly ILogger _logger;

        public EmployeeBenefitsController(IEmployeeBenefitsService employeeBenefitsService, ILogger<EmployeeBenefitsController> logger)
        {
            _employeeBenefitsService = employeeBenefitsService;
            _logger = logger;
        }

        [HttpPost]
        [Route("cost")]
        public async Task<IActionResult> GetEmployeeBenefitsCost(Employee emp)
        {
            try
            {
                return Ok(await _employeeBenefitsService.CalculateEmployeeBenefitsCost(emp));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
