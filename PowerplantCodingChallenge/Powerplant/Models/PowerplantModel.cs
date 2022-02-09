using Powerplant.Extensions;
using Powerplant.Models.Enums;
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

        /// <summary>
        /// Specific constructor.
        /// </summary>
        /// <param name="name">The name of powerplant.</param>
        /// <param name="type">The type of powerplant.</param>
        /// <param name="efficiency">The efficienct of the powerplant.</param>
        /// <param name="pMin">The minimal produced power.</param>
        /// <param name="pMax">Maximal available power of the powerplant.</param>
        public PowerplantModel(string name, string type, double efficiency, int pMin, int pMax)
        {
            Name = name;
            Type = type;
            Efficiency = efficiency;
            PMin = pMin;
            PMax = pMax;
        }

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
        /// <param name="fuel">Input <see cref="FuelModel"/></param>
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
        /// Get the minimum power of the current powerplant.
        /// </summary>
        /// <param name="fuel">Input <see cref="FuelModel"/>, null by default</param>
        /// <returns>
        /// Returns minimal available power of current powerplant.
        /// If the current powerplant is <see cref="PowerplantType.Windturbine"/>, it will return windturbine's actual produced power.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMinPower(FuelModel fuel = null)
        {
            return !IsWindTurbine()
                ? PMin : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }

        /// <summary>
        /// Get the maximum power of the current power plant.
        /// </summary>
        /// <param name="fuel">Input <see cref="FuelModel"/>, null by default</param>
        /// <returns>
        /// Returns maximal available power of current powerplant.
        /// If the current powerplant is <see cref="PowerplantType.Windturbine"/>, it will return windturbine's actual produced power.
        /// </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public double GetMaxPower(FuelModel fuel = null)
        {
            return !IsWindTurbine()
                ? PMax : fuel is not null
                ? fuel.Wind / 100 * PMax : throw new ArgumentNullException(nameof(fuel));
        }
    }
}
