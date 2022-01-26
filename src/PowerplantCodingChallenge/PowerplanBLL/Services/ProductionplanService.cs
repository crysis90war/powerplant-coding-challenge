using PowerplanBLL.Entities;
using PowerplanBLL.Interfaces;

namespace PowerplanBLL.Services;

public class ProductionplanService : IProductionplanService
{
    public IEnumerable<ResultEntity> MeritOrderOfPowerplants(PayloadEntity payload)
    {
        List<ResultEntity> output = new();
        List<PowerplantEntity> powerPlants = payload.GetSortedPowerPlants().ToList();

        double leftLoad = payload.Load;

        for (int index = 0; index < powerPlants.Count; index++)
        {
            PowerplantEntity powerPlant = powerPlants[index];
            PowerplantEntity nextPowerPlant = index + 1 >= powerPlants.Count ? null : powerPlants[index + 1];

            double pMinOutput = powerPlant.GetMinPower(payload.Fuels);
            double pMaxOutput = powerPlant.GetMaxPower(payload.Fuels);

            double nextPMinOutput = nextPowerPlant is null ? 0 : nextPowerPlant.GetMinPower(payload.Fuels);

            if (leftLoad > pMaxOutput && (leftLoad - pMaxOutput) < nextPMinOutput)
            {
                if (powerPlant.IsWindTurbine())
                {
                    int leftLoadAfterSubstraction = Convert.ToInt32(leftLoad - pMaxOutput);

                    bool listContainsLeftLoadAfterSubstraction = powerPlants
                        .Any(c => leftLoadAfterSubstraction >= c.PMin && leftLoadAfterSubstraction <= c.PMax && !c.IsWindTurbine());

                    bool listContainsLeftLoad = powerPlants
                        .Any(c => leftLoad >= c.PMin && leftLoad <= c.PMax && !c.IsWindTurbine());

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
            else output.Add(new(powerPlant.Name, 0));
        }

        return output;
    }

    public IEnumerable<ResultEntity> MeritOrderOfPowerplants2(PayloadEntity payload)
    {
        List<PowerplantEntity> powerPlants = payload.GetSortedPowerPlants().ToList();

        double leftLoad = payload.Load;
        int index = 0;

        foreach (PowerplantEntity powerplant in powerPlants)
        {
            PowerplantEntity nextPowerplant = GetNextPowerplant(powerPlants, index);
            double pMinOutput = powerplant.GetMinPower(payload.Fuels);
            double pMaxOutput = powerplant.GetMaxPower(payload.Fuels);
            double nextPMinOutput = nextPowerplant is null ? 0 : nextPowerplant.GetMinPower(payload.Fuels);

            if (leftLoad > pMaxOutput && (leftLoad - pMaxOutput) < nextPMinOutput)
            {
                if (powerplant.IsWindTurbine())
                {
                    int leftLoadAfterSubstraction = Convert.ToInt32(leftLoad - pMaxOutput);

                    bool listContainsLeftLoadAfterSubstraction = powerPlants
                        .Any(c => leftLoadAfterSubstraction >= c.PMin && leftLoadAfterSubstraction <= c.PMax && !c.IsWindTurbine());

                    bool listContainsLeftLoad = powerPlants
                        .Any(c => leftLoad >= c.PMin && leftLoad <= c.PMax && !c.IsWindTurbine());

                    if (listContainsLeftLoadAfterSubstraction && !listContainsLeftLoad)
                    {
                        yield return new()
                        {
                            Name = powerplant.Name,
                            P = (int)Math.Round(pMaxOutput)
                        };
                        leftLoad -= (int)Math.Round(pMaxOutput);
                    }
                    else
                    {
                        yield return new()
                        {
                            Name = powerplant.Name,
                            P = 0
                        };
                    }
                }
                else
                {
                    double temp = leftLoad - nextPMinOutput;
                    yield return new()
                    {
                        Name = powerplant.Name,
                        P = (int)Math.Round(temp)
                    };

                    leftLoad -= temp;
                }
            }
            else if (leftLoad > pMinOutput)
            {
                if (leftLoad - pMaxOutput > 0)
                {
                    yield return new()
                    {
                        Name = powerplant.Name,
                        P = (int)Math.Round(pMaxOutput)
                    };

                    leftLoad -= pMaxOutput;
                }
                else
                {
                    yield return new()
                    {
                        Name = powerplant.Name,
                        P = (int)Math.Round(leftLoad)
                    };

                    leftLoad -= leftLoad;
                }
            }
            else
            {
                yield return new()
                {
                    Name = powerplant.Name,
                    P = 0
                };
            }
            index++;
        }
    }

    private PowerplantEntity GetNextPowerplant(List<PowerplantEntity> powerplants, int index)
    {
        index += 1;
        return index + 1 >= powerplants.Count ? null : powerplants[index + 1];
    }
}
