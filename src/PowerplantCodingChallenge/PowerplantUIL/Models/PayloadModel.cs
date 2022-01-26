using System.ComponentModel.DataAnnotations;

namespace PowerplantUIL.Models;

public class PayloadModel
{
    [Required]
    public int Load { get; set; }
    public FuelModel Fuels { get; set; }
    public IEnumerable<PowerplantModel> Powerplants { get; set; }
}
