using System.ComponentModel.DataAnnotations;

namespace PowerplantUIL.Models;

public class PayloadModel
{
    [Required]
    public int Load { get; set; }

    [Required]
    public FuelModel Fuels { get; set; }
    
    [Required]
    [MinLength(1)]
    public IEnumerable<PowerplantModel> Powerplants { get; set; }
}
