using Powerplant.Models;
using Powerplant.Models.Forms;

namespace Powerplant.Services
{
    public interface IPowerplantService
    {
        public IEnumerable<ResultModel> ResultCalculation(PayloadForm paylaod);
    }
}
