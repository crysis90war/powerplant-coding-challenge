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

    /// <summary>
    /// Default constructor.
    /// </summary>
    public FuelModel() {}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="gas"></param>
    /// <param name="kerosine"></param>
    /// <param name="co2"></param>
    /// <param name="wind"></param>
    public FuelModel(double gas, double kerosine, double co2, double wind)
    {
        Gas = gas;
        Kerosine = kerosine;
        Co2 = co2;
        Wind = wind;
    }
}
