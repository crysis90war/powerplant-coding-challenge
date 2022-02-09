using Powerplant.Enums;
using Powerplant.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Powerplant.Models
{
    public class PowerplantModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double Efficiency { get; set; }

        [Required]
        public int PMin { get; set; }

        [Required]
        public int PMax { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PowerplantModel() { }

        public PowerplantModel(string name, string type, double efficiency, int pMin, int pMax)
        {
            Name = name;
            Type = type;
            Efficiency = efficiency;
            PMin = pMin;
            PMax = pMax;
        }

        /// <summary>
        /// Verifies if the actual <see cref="PowerplantEntity"/> is Type of <see cref="PowerplantType.Windturbine"/>.
        /// </summary>
        /// <returns>Return true else false</returns>
        public bool IsWindTurbine()
        {
            return Type.StringToEnum() == PowerplantType.Windturbine;
        }

        /// <summary>
        /// Calculates and returns the price per MWh of this <see cref="PowerplantEntity"/> 
        /// based on its <see cref="Type"/>
        /// </summary>
        /// <param name="fuel">Input <see cref="FuelEntity"/></param>
        /// <returns>Calculated price in decimal</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal GetProductionPrice(FuelModel fuel)
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
        /// Get the minimum power of the actual power plant.
        /// If the type is <see cref="PowerplantType.Windturbine"/>, it returns windturbine's actual produced power.
        /// </summary>
        /// <param name="fuel">Input <see cref="FuelEntity"/>, null by default</param>
        /// <returns>The calculated minimal power of this Powerplant</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMinPower(FuelModel fuel = null)
        {
            return !IsWindTurbine()
                ? PMin : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }

        /// <summary>
        /// Get the maximum power of the actual power plant.
        /// If the type is <see cref="PowerplantType.Windturbine"/>, it returns windturbine's actual produced power.
        /// </summary>
        /// <param name="fuel">Input <see cref="FuelEntity"/>, null by default</param>
        /// <returns>The calculated maximal power of this Powerplant</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMaxPower(FuelModel fuel = null)
        {
            return !IsWindTurbine()
                ? PMax : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }
    }
}
