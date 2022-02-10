using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class Payload
    {
        /// <summary>
        /// Stores the power to be produced by the power plants in this payload.
        /// </summary>
        [Required]
        public int Load { get; set; }

        /// <summary>
        /// Stores the fuel object in this payload.
        /// </summary>
        [Required]
        public Fuel Fuels { get; set; }

        /// <summary>
        /// Stores the list of power plants in this payload.
        /// </summary>
        [Required]
        [MinLength(1)]
        public IEnumerable<Powerplant> Powerplants { get; set; }

        /// <summary>
        /// Sorts the elements of <see cref="Powerplants"/> in descending order according to <see cref="Powerplant.PMax"/> then in ascending according to the calculated price of MWh (<see cref="Powerplant.GetProductionPrice(Fuel)")/>.
        /// </summary>
        /// <returns>Returns a list of powerplants whose elements are sorted.</returns>
        public IEnumerable<Powerplant> GetSortedPowerPlants()
        {
            return Powerplants
                .OrderByDescending(p => p.PMax)
                .OrderBy(p => p.GetProductionPrice(Fuels));
        }
    }
}
