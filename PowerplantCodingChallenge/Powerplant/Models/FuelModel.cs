using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Powerplant.Models
{
    public class FuelModel
    {
        [Required]
        [JsonPropertyName("gas(euro/MWh)")]
        public double Gas { get; set; }

        [Required]
        [JsonPropertyName("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        [Required]
        [JsonPropertyName("co2(euro/ton)")]
        public double Co2 { get; set; }

        [Required]
        [JsonPropertyName("wind(%)")]
        public double Wind { get; set; }
    }
}
