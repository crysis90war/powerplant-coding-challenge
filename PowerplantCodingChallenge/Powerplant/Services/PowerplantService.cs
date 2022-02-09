using Powerplant.Models;
using Powerplant.Models.Forms;

namespace Powerplant.Services
{
    public class PowerplantService : IPowerplantService
    {
        /// <summary>
        /// Calculates and generates a list of result from a payload.
        /// </summary>
        /// <param name="payload">Takes in the payload</param>
        /// <returns>Returns a list of results.</returns>
        public IEnumerable<ResultModel> ResultCalculation(PayloadForm payload)
        {
            List<ResultModel> output = new();
            List<PowerplantModel> powerPlants = payload.GetSortedPowerPlants().ToList();

            double leftLoad = payload.Load;

            for (int index = 0; index < powerPlants.Count; index++)
            {
                PowerplantModel powerPlant = powerPlants[index];
                PowerplantModel nextPowerPlant = index + 1 >= powerPlants.Count ? null : powerPlants[index + 1];

                double pMinOutput = powerPlant.GetMinPower(payload.Fuels);
                double pMaxOutput = powerPlant.GetMaxPower(payload.Fuels);

                double nextPMinOutput = nextPowerPlant is null ? 0 : nextPowerPlant.GetMinPower(payload.Fuels);

                if (leftLoad > pMaxOutput && (leftLoad - pMaxOutput) < nextPMinOutput)
                {
                    if (powerPlant.IsWindTurbine())
                    {
                        int leftLoadAfterSubstraction = Convert.ToInt32(leftLoad - pMaxOutput);

                        bool listContainsLeftLoadAfterSubstraction = powerPlants.Any(c => leftLoadAfterSubstraction >= c.PMin && leftLoadAfterSubstraction <= c.PMax && !c.IsWindTurbine());
                        bool listContainsLeftLoad = powerPlants.Any(c => leftLoad >= c.PMin && leftLoad <= c.PMax && !c.IsWindTurbine());

                        if (listContainsLeftLoadAfterSubstraction && !listContainsLeftLoad)
                        {
                            output.Add(new(powerPlant.Name, (int)Math.Round(pMaxOutput)));

                            leftLoad -= (int)Math.Round(pMaxOutput);
                        }
                        else output.Add(new(powerPlant.Name, 0));
                    }
                    else
                    {
                        double temp = leftLoad - nextPMinOutput;
                        output.Add(new(powerPlant.Name, (int)Math.Round(temp)));

                        leftLoad -= temp;
                    }
                }
                else if (leftLoad >= pMinOutput)
                {
                    if (leftLoad - pMaxOutput > 0)
                    {
                        output.Add(new(powerPlant.Name, (int)Math.Round(pMaxOutput)));

                        leftLoad -= pMaxOutput;
                    }
                    else
                    {
                        output.Add(new(powerPlant.Name, (int)Math.Round(leftLoad)));

                        leftLoad -= leftLoad;
                    }
                }
                else
                {
                    output.Add(new(powerPlant.Name, 0));
                }
            }

            return output;
        }
    }
}
