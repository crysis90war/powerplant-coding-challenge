namespace PowerplanBLL.Entities;

public class PayloadEntity
{
    public int Load { get; set; }
    public FuelEntity Fuels { get; set; }
    public IEnumerable<PowerplantEntity> Powerplants { get; set; } = new List<PowerplantEntity>();

    /// <summary>
    /// Sorts the elements of <see cref="PayloadEntity.Powerplants"/> in descending order according to <see cref="PowerplantEntity.PMax"/>,
    /// then in ascending according to the calculated price of MWh.
    /// </summary>
    /// <returns>An <see cref="IEnu"/> whose elements are sorted.</returns>
    public IEnumerable<PowerplantEntity> GetSortedPowerPlants()
    {
        return Powerplants
            .OrderByDescending(p => p.PMax)
            .OrderBy(p => p.Calculate(Fuels));
    }
}
