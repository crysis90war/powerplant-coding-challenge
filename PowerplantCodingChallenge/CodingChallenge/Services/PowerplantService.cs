using CodingChallenge.Models;

namespace CodingChallenge.Services
{
    public class PowerplantService : IPowerplantService
    {
        public IEnumerable<Result> CalculateResult(Payload payload)
        {
            List<Result> output = new List<Result>();

            List<Powerplant> powerPlants = payload.GetSortedPowerPlants().ToList();

            double leftLoad = payload.Load;

            for (int index = 0; index < powerPlants.Count; index++)
            {
                Powerplant powerPlant = powerPlants[index];

                Powerplant nextPowerPlant = index + 1 >= powerPlants.Count ? null : powerPlants[index + 1];

                int power = 0;

                double pMinOutput = powerPlant.GetMinPower(payload.Fuels);

                double pMaxOutput = powerPlant.GetMaxPower(payload.Fuels);

                double nextPMinOutput = nextPowerPlant is null ? 0 : nextPowerPlant.GetMinPower(payload.Fuels);

                double leftLoadAfterSubstraction = leftLoad - pMaxOutput;

                if (leftLoad > pMaxOutput && leftLoadAfterSubstraction < nextPMinOutput)
                {
                    if (powerPlant.IsWindTurbine())
                    {
                        bool listContainsLeftLoadAfterSubstraction = powerPlants.Any(powerplant => (int)leftLoadAfterSubstraction >= powerplant.PMin && (int)leftLoadAfterSubstraction <= powerplant.PMax && !powerplant.IsWindTurbine());

                        bool listContainsLeftLoad = powerPlants.Any(powerplant => leftLoad >= powerplant.PMin && leftLoad <= powerplant.PMax && !powerplant.IsWindTurbine());

                        if (listContainsLeftLoadAfterSubstraction && !listContainsLeftLoad)
                        {
                            power = (int)Math.Round(pMaxOutput);

                            leftLoad -= (int)Math.Round(pMaxOutput);
                        }
                        else
                        {
                            power = 0;
                        }
                    }
                    else
                    {
                        double temp = leftLoad - nextPMinOutput;

                        power = (int)Math.Round(temp);

                        leftLoad -= temp;
                    }
                }
                else if (leftLoad >= pMinOutput)
                {
                    if (leftLoadAfterSubstraction > 0)
                    {
                        power = (int)Math.Round(pMaxOutput);

                        leftLoad -= pMaxOutput;
                    }
                    else
                    {
                        power = (int)Math.Round(leftLoad);

                        leftLoad -= leftLoad;
                    }
                }
                else
                {
                    power = 0;
                }

                output.Add(new Result()
                {
                    Name = powerPlant.Name,
                    P = power
                });
            }

            return output;
        }
    }
}
