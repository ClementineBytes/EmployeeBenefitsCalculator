using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace EmployeeBenefitsCalculator.Controllers
{
    [Route("v2/benefits")]
    public class BenefitsV2Controller : Controller
    {
        [Route("cost")]
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.Forbidden)]
        [SwaggerResponse((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetBenefitsCost() 
        {
            //TODO
        }
    }
}
