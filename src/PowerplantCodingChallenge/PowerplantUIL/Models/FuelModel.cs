using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerplantUIL.Models;

public class FuelModel
{
    [JsonPropertyName("gas(euro/MWh)")]
    [Required]
    public double Gas { get; set; }

    [JsonPropertyName("kerosine(euro/MWh)")]
    [Required]
    public double Kerosine { get; set; }

    [JsonPropertyName("co2(euro/ton)")]
    [Required]
    public double Co2 { get; set; }

    [JsonPropertyName("wind(%)")]
    [Required]
    public double Wind { get; set; }
}
