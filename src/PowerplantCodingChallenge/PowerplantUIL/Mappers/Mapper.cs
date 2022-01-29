using PowerplanBLL.Entities;
using UIL = PowerplantUIL.Enums;
using BLL = PowerplanBLL.Enums;
using PowerplantUIL.Models;
using PowerplantUIL.Extensions;

namespace PowerplantUIL.Mappers;

/// <summary>
/// Mapper extentions methods
/// </summary>
internal static class Mapper
{
    /* Payload */

    /// <summary>
    /// Converts <see cref="typeof(PayloadEntity)"/> to  <see cref="typeof(PayloadModel)"/>
    /// </summary>
    /// <param name="entity">Takes <see cref="typeof(PayloadEntity)"/></param>
    /// <returns></returns>
    internal static PayloadModel ToUil(this PayloadEntity entity) => new()
    {
        Load = entity.Load,
        Fuels = entity.Fuels.ToUil(),
        Powerplants = entity.Powerplants.Select(x => x.ToUil()),
    };

    /// <summary>
    /// Extension method that converts <see cref="PayloadModel"/> to <see cref="PayloadEntity"/>
    /// </summary>
    /// <param name="model">Takes <see cref="typeof(PayloadModel)"/></param>
    /// <returns>Returns converted model <see cref="PayloadModel"/> to entity <see cref="PayloadEntity"/></returns>
    internal static PayloadEntity ToBll(this PayloadModel model) => new()
    {
        Load = model.Load,
        Fuels = model.Fuels.ToBll(),
        Powerplants = model.Powerplants.Select(x => x.ToBll()),
    };

    /* Fuel */

    internal static FuelModel ToUil(this FuelEntity entity) => new()
    {
        Gas = entity.Gas,
        Kerosine = entity.Kerosine,
        Co2 = entity.Co2,
        Wind = entity.Wind
    };

    internal static FuelEntity ToBll(this FuelModel model) => new()
    {
        Gas = model.Gas,
        Kerosine = model.Kerosine,
        Co2 = model.Co2,
        Wind = model.Wind
    };

    /* Powerplant */

    internal static PowerplantModel ToUil(this PowerplantEntity entity) => new()
    {
        Name = entity.Name,
        Type = entity.Type.GetString(),
        Efficiency = entity.Efficiency,
        PMin = entity.PMin,
        PMax = entity.PMax
    };

    internal static PowerplantEntity ToBll(this PowerplantModel model) => new()
    {
        Name = model.Name,
        Type = model.Type.GetEnumType(),
        Efficiency = model.Efficiency,
        PMin = model.PMin,
        PMax = model.PMax
    };

    /* Result */

    internal static ResultModel ToUil(this ResultEntity entity) => new()
    {
        Name = entity.Name,
        P = entity.P,
    };

    internal static ResultEntity ToBll(this ResultModel model) => new()
    {
        Name = model.Name,
        P = model.P,
    };
}
