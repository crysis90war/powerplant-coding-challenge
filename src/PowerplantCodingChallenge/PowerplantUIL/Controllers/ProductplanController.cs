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
        form = Faker.GetFirstPayload();

        IEnumerable<ResultModel> results = _productionplanService.MeritOrderOfPowerplants(form.ToBll()).Select(x => x.ToUil());
        return Ok(results);
    }
}
