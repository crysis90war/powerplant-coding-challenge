using PowerplantUIL.Enums;
using System.ComponentModel.DataAnnotations;

namespace PowerplantUIL.Models;

public class PowerplantModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public PowerplantType Type { get; set; }

    [Required]
    public double Efficiency { get; set; }

    [Required]
    public int PMin { get; set; }

    [Required]
    public int PMax { get; set; }
}
