using System.ComponentModel.DataAnnotations;

namespace Powerplant.Models.Forms
{
    public class PayloadForm
    {
        [Required]
        public int Load { get; set; }

        [Required]
        public FuelModel Fuels { get; set; }

        [Required]
        [MinLength(1)]
        public IEnumerable<PowerplantModel> Powerplants { get; set; }

        /// <summary>
        /// Sorts the elements of <see cref="PayloadForm.Powerplants"/> in descending order according to <see cref="PayloadForm.PMax"/>,
        /// then in ascending according to the calculated price of MWh.
        /// </summary>
        /// <returns>Returns a list of powerplants whose elements are sorted.</returns>
        public IEnumerable<PowerplantModel> GetSortedPowerPlants()
        {
            return Powerplants
                .OrderByDescending(p => p.PMax)
                .OrderBy(p => p.GetProductionPrice(Fuels));
        }
    }
}
