using PowerplantUIL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PowerplantUIL.Models;

public class PowerplantModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public double Efficiency { get; set; }

    [Required]
    public int PMin { get; set; }

    [Required]
    public int PMax { get; set; }

    public PowerplantModel() {}

    public PowerplantModel(string name, string type, double efficiency, int pMin, int pMax)
    {
        Name = name;
        Type = type;
        Efficiency = efficiency;
        PMin = pMin;
        PMax = pMax;
    }
}
