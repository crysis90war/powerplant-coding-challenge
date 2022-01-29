using PowerplantUIL.Enums;
using PowerplantUIL.Models;

namespace PowerplantUIL.Fakers;

internal static class Faker
{
    /// <summary>
    /// Returns a preset of <see cref="PayloadModel"/>
    /// </summary>
    /// <param name="key">Integer key value</param>
    /// <returns><see cref="PayloadModel"/></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    internal static PayloadModel GetPayload(int key)
    {
        Dictionary<int, PayloadModel> payload = new()
        {
            {
                1,
                new()
                {
                    Load = 480,
                    Fuels = new()
                    {
                        Gas = 13.4,
                        Kerosine = 50.8,
                        Co2 = 20,
                        Wind = 60
                    },
                    Powerplants = new List<PowerplantModel>()
                    {
                        new()
                        {
                            Name = "gasfiredbig1",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name = "gasfiredbig2",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name="gasfiredsomewhatsmaller",
                            Type=PowerplantType.Gasfired,
                            Efficiency=0.37,
                            PMin=40,
                            PMax = 210
                        },
                        new()
                        {
                            Name = "tj1",
                            Type = PowerplantType.Turbojet,
                            Efficiency = 0.3,
                            PMin = 0,
                            PMax = 16
                        },
                        new()
                        {
                            Name = "windpark1",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 150
                        },
                        new()
                        {
                            Name = "windpark2",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 36
                        },
                    }
                }
            },
            {
                2,
                new()
                {

                    Load = 480,
                    Fuels = new()
                    {
                        Gas = 13.4,
                        Kerosine = 50.8,
                        Co2 = 20,
                        Wind = 0
                    },
                    Powerplants = new List<PowerplantModel>()
                    {
                        new()
                        {
                            Name = "gasfiredbig1",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name = "gasfiredbig2",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name="gasfiredsomewhatsmaller",
                            Type=PowerplantType.Gasfired,
                            Efficiency=0.37,
                            PMin=40,
                            PMax = 210
                        },
                        new()
                        {
                            Name = "tj1",
                            Type = PowerplantType.Turbojet,
                            Efficiency = 0.3,
                            PMin = 0,
                            PMax = 16
                        },
                        new()
                        {
                            Name = "windpark1",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 150
                        },
                        new()
                        {
                            Name = "windpark2",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 36
                        },
                    }
                }
            },
            {
                3,
                new()
                {

                    Load = 910,
                    Fuels = new()
                    {
                        Gas = 13.4,
                        Kerosine = 50.8,
                        Co2 = 20,
                        Wind = 60
                    },
                    Powerplants = new List<PowerplantModel>()
                    {
                        new()
                        {
                            Name = "gasfiredbig1",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name = "gasfiredbig2",
                            Type = PowerplantType.Gasfired,
                            Efficiency = 0.53,
                            PMin = 100,
                            PMax = 460
                        },
                        new()
                        {
                            Name="gasfiredsomewhatsmaller",
                            Type=PowerplantType.Gasfired,
                            Efficiency=0.37,
                            PMin=40,
                            PMax = 210
                        },
                        new()
                        {
                            Name = "tj1",
                            Type = PowerplantType.Turbojet,
                            Efficiency = 0.3,
                            PMin = 0,
                            PMax = 16
                        },
                        new()
                        {
                            Name = "windpark1",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 150
                        },
                        new()
                        {
                            Name = "windpark2",
                            Type = PowerplantType.Windturbine,
                            Efficiency = 1,
                            PMin = 0,
                            PMax = 36
                        },
                    }
                }
            }
        };

        return key switch
        {
            1 => payload.GetValueOrDefault(key),
            2 => payload.GetValueOrDefault(key),
            3 => payload.GetValueOrDefault(key),
            _ => throw new ArgumentOutOfRangeException(nameof(key), $"Not expected key, choose between 1 and {payload.Count}"),
        };
    }
}