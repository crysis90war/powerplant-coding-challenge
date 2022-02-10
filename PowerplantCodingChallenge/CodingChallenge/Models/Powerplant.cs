using CodingChallenge.Extensions;
using CodingChallenge.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class Powerplant
    {
        /// <summary>
        /// Stored the name of this powerplant.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Stored the type of this powerplant.
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Stored the efficiency of this powerplant.
        /// </summary>
        [Required]
        public double Efficiency { get; set; }

        /// <summary>
        /// Stores the minimal produced power of this powerplant.
        /// </summary>
        [Required]
        public int PMin { get; set; }

        /// <summary>
        /// Stores the maximal produced power of this powerplant.
        /// </summary>
        [Required]
        public int PMax { get; set; }

        /// <summary>
        /// Verifies if the current powerplant is type of <see cref="PowerplantType.Windturbine"/>.
        /// </summary>
        /// <returns>Return true else false</returns>
        public bool IsWindTurbine()
        {
            return Type.StringToEnum() == PowerplantType.Windturbine;
        }

        /// <summary>
        /// Calculates and returns the price per MWh of current powerplant based on its type.
        /// </summary>
        /// <param name="fuel">Input <see cref="Fuel"/></param>
        /// <returns>Calculated price in decimal</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal GetProductionPrice(Fuel fuel)
        {
            return Type.StringToEnum() switch
            {
                PowerplantType.Turbojet => Convert.ToDecimal(fuel.Kerosine / Efficiency),
                PowerplantType.Gasfired => Convert.ToDecimal(fuel.Gas / Efficiency),
                PowerplantType.Windturbine => 0m,
                _ => throw new ArgumentOutOfRangeException(nameof(Type), $"Not expected power plant: {Type}"),
            };
        }

        /// <summary>
        /// Get the minimum power of the current powerplant.
        /// </summary>
        /// <param name="fuel">Input <see cref="Fuel"/></param>
        /// <returns>
        /// Returns minimal available power of current powerplant.
        /// If the current powerplant is <see cref="PowerplantType.Windturbine"/>, it will return windturbine's actual produced power.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMinPower(Fuel fuel)
        {
            return !IsWindTurbine()
                ? PMin : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }

        /// <summary>
        /// Get the maximum power of the current powerplant.
        /// </summary>
        /// <param name="fuel">Input <see cref="Fuel"/></param>
        /// <returns>
        /// Returns maximal available power of current powerplant.
        /// If the current powerplant is <see cref="PowerplantType.Windturbine"/>, it will return windturbine's actual produced power.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMaxPower(Fuel fuel)
        {
            return !IsWindTurbine()
                ? PMax : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }
    }
}
