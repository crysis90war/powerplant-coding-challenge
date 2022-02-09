using Powerplant.Models;
using Powerplant.Models.Forms;

namespace Powerplant.Services
{
    public interface IPowerplantService
    {
        /// <summary>
        /// Calculates and generates a list of result from a payload.
        /// </summary>
        /// <param name="payload">Takes in the payload</param>
        /// <returns>Returns a list of <see cref="ResultModel"/>.</returns>
        public IEnumerable<ResultModel> CalculateResult(PayloadForm paylaod);
    }
}
