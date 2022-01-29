﻿using PowerplantUIL.Enums;
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
                    Fuels = new(
                        13.4,
                        50.8,
                        20,
                        60),
                    Powerplants = new List<PowerplantModel>()
                    {
                        new(
                            "gasfiredbig1",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredbig2",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredsomewhatsmaller",
                            "gasfired",
                            0.37,
                            40,
                            210),
                        new(
                            "tj1",
                            "turbojet",
                            0.3,
                            0,
                            16),
                        new(
                            "windpark1",
                            "windturbine",
                            1,
                            0,
                            150),
                        new(
                            "windpark2",
                            "windturbine",
                            1,
                            0,
                            36)
                    }
                }
            },
            {
                2,
                new()
                {

                    Load = 480,
                    Fuels = new(
                        13.4,
                        50.8,
                        20,
                        0),
                    Powerplants = new List<PowerplantModel>()
                    {
                        new(
                            "gasfiredbig1",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredbig2",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredsomewhatsmaller",
                            "gasfired",
                            0.37,
                            40,
                            210),
                        new(
                            "tj1",
                            "turbojet",
                            0.3,
                            0,
                            16),
                        new(
                            "windpark1",
                            "windturbine",
                            1,
                            0,
                            150),
                        new(
                            "windpark2",
                            "windturbine",
                            1,
                            0,
                            36)
                    }
                }
            },
            {
                3,
                new()
                {

                    Load = 910,
                    Fuels = new(
                        13.4,
                        50.8,
                        20,
                        60),
                    Powerplants = new List<PowerplantModel>()
                    {
                        new(
                            "gasfiredbig1",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredbig2",
                            "gasfired",
                            0.53,
                            100,
                            460),
                        new(
                            "gasfiredsomewhatsmaller",
                            "gasfired",
                            0.37,
                            40,
                            210),
                        new(
                            "tj1",
                            "turbojet",
                            0.3,
                            0,
                            16),
                        new(
                            "windpark1",
                            "windturbine",
                            1,
                            0,
                            150),
                        new(
                            "windpark2",
                            "windturbine",
                            1,
                            0,
                            36)
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