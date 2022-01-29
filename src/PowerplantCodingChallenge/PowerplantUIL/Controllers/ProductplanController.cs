using Microsoft.AspNetCore.Mvc;
using PowerplanBLL.Interfaces;
using PowerplantUIL.Fakers;
using PowerplantUIL.Mappers;
using PowerplantUIL.Models;

namespace PowerplantUIL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductplanController : ControllerBase
{
    private readonly IProductionplanService _productionplanService;

    public ProductplanController(IProductionplanService productionplanService)
    {
        _productionplanService = productionplanService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] PayloadModel form)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        try
        {
            // form = Faker.GetPayload(1);

            IEnumerable<ResultModel> results = _productionplanService.MeritOrderOfPowerplants(form.ToBll()).Select(x => x.ToUil());
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
