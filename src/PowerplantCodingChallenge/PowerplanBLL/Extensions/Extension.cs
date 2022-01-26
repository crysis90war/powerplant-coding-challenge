
using PowerplanBLL.Enums;

namespace PowerplanBLL.Extensions;

public static class Extension
{
    public static string GetString(this PowerplantType powerPlant) => powerPlant switch
    {
        PowerplantType.Gasfired => "gasfired",
        PowerplantType.Turbojet => "turbojet",
        PowerplantType.Windturbine => "windturbine",
        _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
    };

    public static double GetEmission(this PowerplantType powerPlant) => powerPlant switch
    {
        PowerplantType.Gasfired => 0.3,
        PowerplantType.Turbojet => 0.3,
        PowerplantType.Windturbine => 0,
        _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
    };
}
