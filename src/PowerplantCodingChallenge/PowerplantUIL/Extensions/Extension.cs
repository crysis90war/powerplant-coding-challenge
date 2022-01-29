
using PowerplanBLL.Enums;

namespace PowerplantUIL.Extensions;

public static class Extension
{
    private const string _gasfired = "gasfired";
    private const string _turbojet = "turbojet";
    private const string _windturbine = "windturbine";

    public static string GetString(this PowerplantType powerPlant) => powerPlant switch
    {
        PowerplantType.Gasfired => _gasfired,
        PowerplantType.Turbojet => _turbojet,
        PowerplantType.Windturbine => _windturbine,
        _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
    };

    public static PowerplantType GetEnumType(this string str) => str switch
    {
        _gasfired => PowerplantType.Gasfired,
        _turbojet => PowerplantType.Turbojet,
        _windturbine => PowerplantType.Windturbine,
        _ => throw new ArgumentOutOfRangeException(nameof(str), $"Not expected power plant: {str}"),
    };

    public static double GetEmission(this PowerplantType powerPlant) => powerPlant switch
    {
        PowerplantType.Gasfired => 0.3,
        PowerplantType.Turbojet => 0.3,
        PowerplantType.Windturbine => 0,
        _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
    };
}
