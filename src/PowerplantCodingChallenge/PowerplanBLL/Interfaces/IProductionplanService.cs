using PowerplanBLL.Entities;

namespace PowerplanBLL.Interfaces;

public interface IProductionplanService
{
    public IEnumerable<ResultEntity> MeritOrderOfPowerplants(PayloadEntity paylaod);

    [Obsolete($"{nameof(MeritOrderOfPowerplants2)} is deprecated, please use {nameof(MeritOrderOfPowerplants)} instead.", false)]
    public IEnumerable<ResultEntity> MeritOrderOfPowerplants2(PayloadEntity paylaod);
}
