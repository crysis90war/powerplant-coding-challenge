using Microsoft.AspNetCore.Mvc;
using Powerplant.Models;
using Powerplant.Models.Forms;
using Powerplant.Services;

namespace Powerplant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionplanController : ControllerBase
    {
        private readonly IPowerplantService _service;

        public ProductionplanController(IPowerplantService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PayloadForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // form = Faker.GetPayload(1);
                IEnumerable<ResultModel> results = _service.CalculateResult(form);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
