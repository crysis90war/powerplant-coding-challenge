using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
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
        public IActionResult Post([FromBody] Payload form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // form = Faker.GetPayload(1);
                IEnumerable<Result> results = _service.CalculateResult(form);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
