using Powerplant.Models;
using Powerplant.Models.Forms;

namespace Powerplant.Fakers
{
    public static class Faker
    {
        /// <summary>
        /// Pick up an existing set of payload for test purpose.
        /// </summary>
        /// <param name="key">Integer key value</param>
        /// <returns><see cref="PayloadModel"/>Return select payload</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static PayloadForm GetPayload(int key)
        {
            Dictionary<int, PayloadForm> payload = new()
            {
                {
                    1,
                    new()
                    {
                        Load = 480,
                        Fuels = new FuelModel()
                        {
                            Gas = 13.4,
                            Kerosine = 50.8,
                            Co2 = 20,
                            Wind = 60
                        },
                        Powerplants = new List<PowerplantModel>()
                        {
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig1",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig2",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredsomewhatsmaller",
                                Type = "gasfired",
                                Efficiency = 0.37,
                                PMin = 40,
                                PMax = 210,
                            },
                            new PowerplantModel()
                            {
                                Name = "tj1",
                                Type = "turbojet",
                                Efficiency = 0.3,
                                PMin = 0,
                                PMax = 16,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark1",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 150,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark2",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 36,
                            }
                        }
                    }
                },
                {
                    2,
                    new()
                    {

                        Load = 480,
                        Fuels = new FuelModel()
                        {
                            Gas = 13.4,
                            Kerosine = 50.8,
                            Co2 = 20,
                            Wind = 0
                        },
                        Powerplants = new List<PowerplantModel>()
                        {
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig1",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig2",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredsomewhatsmaller",
                                Type = "gasfired",
                                Efficiency = 0.37,
                                PMin = 40,
                                PMax = 210,
                            },
                            new PowerplantModel()
                            {
                                Name = "tj1",
                                Type = "turbojet",
                                Efficiency = 0.3,
                                PMin = 0,
                                PMax = 16,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark1",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 150,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark2",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 36,
                            }
                        }
                    }
                },
                {
                    3,
                    new()
                    {

                        Load = 910,
                        Fuels = new FuelModel()
                        {
                            Gas = 13.4,
                            Kerosine = 50.8,
                            Co2 = 20,
                            Wind = 60
                        },
                        Powerplants = new List<PowerplantModel>()
                        {
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig1",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredbig2",
                                Type = "gasfired",
                                Efficiency = 0.53,
                                PMin = 100,
                                PMax = 460,
                            },
                            new PowerplantModel()
                            {
                                Name = "gasfiredsomewhatsmaller",
                                Type = "gasfired",
                                Efficiency = 0.37,
                                PMin = 40,
                                PMax = 210,
                            },
                            new PowerplantModel()
                            {
                                Name = "tj1",
                                Type = "turbojet",
                                Efficiency = 0.3,
                                PMin = 0,
                                PMax = 16,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark1",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 150,
                            },
                            new PowerplantModel()
                            {
                                Name = "windpark2",
                                Type = "windturbine",
                                Efficiency = 1,
                                PMin = 0,
                                PMax = 36,
                            }
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
}
