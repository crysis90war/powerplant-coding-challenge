using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CodingChallenge.Models
{
    public class Fuel
    {
        /// <summary>
        /// Stores the price of gas per euro/mwh in this fuel object.
        /// </summary>
        [Required]
        [JsonPropertyName("gas(euro/MWh)")]
        public double Gas { get; set; }

        /// <summary>
        /// Stores the price of kerosine per euro/mwh in this fuel object.
        /// </summary>
        [Required]
        [JsonPropertyName("kerosine(euro/MWh)")]
        public double Kerosine { get; set; }

        /// <summary>
        /// Stores the price of co2 per euro/ton in this fuel object.
        /// </summary>
        [Required]
        [JsonPropertyName("co2(euro/ton)")]
        public double Co2 { get; set; }

        /// <summary>
        /// Store the percentage of wind in this fuel object.
        /// </summary>
        [Required]
        [JsonPropertyName("wind(%)")]
        public double Wind { get; set; }
    }
}
