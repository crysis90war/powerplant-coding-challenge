using PowerplantUIL.Enums;
using PowerplantUIL.Models;

namespace PowerplantUIL.Fakers;

internal static class Faker
{
    internal static PayloadModel GetFirstPayload()
    {
        return new()
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
        };
    }

    internal static PayloadModel GetSecondPayload()
    {
        return new()
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
        };
    }

    internal static PayloadModel GetThirdPayload()
    {
        return new()
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
        };
    }
}