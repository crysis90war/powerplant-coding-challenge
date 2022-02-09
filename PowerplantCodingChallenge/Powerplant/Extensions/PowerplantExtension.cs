using Powerplant.Enums;

namespace Powerplant.Extensions
{
    public static class PowerplantExtension
    {
        private const string _gasfired = "gasfired";
        private const string _turbojet = "turbojet";
        private const string _windturbine = "windturbine";

        public static string EnumToString(this PowerplantType powerPlant)
        {
            return powerPlant switch
            {
                PowerplantType.Gasfired => _gasfired,
                PowerplantType.Turbojet => _turbojet,
                PowerplantType.Windturbine => _windturbine,
                _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
            };
        }

        public static PowerplantType StringToEnum(this string str)
        {
            return str switch
            {
                _gasfired => PowerplantType.Gasfired,
                _turbojet => PowerplantType.Turbojet,
                _windturbine => PowerplantType.Windturbine,
                _ => throw new ArgumentOutOfRangeException(nameof(str), $"Not expected power plant: {str}"),
            };
        }

        public static double GetEmission(this PowerplantType powerPlant)
        {
            return powerPlant switch
            {
                PowerplantType.Gasfired => 0.3,
                PowerplantType.Turbojet => 0.3,
                PowerplantType.Windturbine => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(powerPlant), $"Not expected power plant: {powerPlant}"),
            };
        }
    }
}
