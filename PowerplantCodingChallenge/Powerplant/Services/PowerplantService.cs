using Powerplant.Models;
using Powerplant.Models.Forms;

namespace Powerplant.Services
{
    public class PowerplantService : IPowerplantService
    {
        public IEnumerable<ResultModel> CalculateResult(PayloadForm payload)
        {
            List<ResultModel> output = new List<ResultModel>();

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

                        bool listContainsLeftLoadAfterSubstraction = powerPlants.Any(powerplant => leftLoadAfterSubstraction >= powerplant.PMin && leftLoadAfterSubstraction <= powerplant.PMax && !powerplant.IsWindTurbine());

                        bool listContainsLeftLoad = powerPlants.Any(powerplant => leftLoad >= powerplant.PMin && leftLoad <= powerplant.PMax && !powerplant.IsWindTurbine());

                        if (listContainsLeftLoadAfterSubstraction && !listContainsLeftLoad)
                        {
                            output.Add(new ResultModel()
                            {
                                Name = powerPlant.Name,
                                P = (int)Math.Round(pMaxOutput)
                            });

                            leftLoad -= (int)Math.Round(pMaxOutput);
                        }
                        else
                        {
                            output.Add(new ResultModel()
                            {
                                Name = powerPlant.Name,
                                P = 0
                            });
                        }
                    }
                    else
                    {
                        double temp = leftLoad - nextPMinOutput;

                        output.Add(new ResultModel()
                        {
                            Name = powerPlant.Name,
                            P = (int)Math.Round(temp)
                        });

                        leftLoad -= temp;
                    }
                }
                else if (leftLoad >= pMinOutput)
                {
                    if (leftLoad - pMaxOutput > 0)
                    {
                        output.Add(new ResultModel()
                        {
                            Name = powerPlant.Name,
                            P = (int)Math.Round(pMaxOutput)
                        });

                        leftLoad -= pMaxOutput;
                    }
                    else
                    {
                        output.Add(new ResultModel()
                        {
                            Name = powerPlant.Name,
                            P = (int)Math.Round(leftLoad)
                        });

                        leftLoad -= leftLoad;
                    }
                }
                else
                {
                    output.Add(new ResultModel()
                    {
                        Name = powerPlant.Name,
                        P = 0
                    });
                }
            }

            return output;
        }
    }
}
