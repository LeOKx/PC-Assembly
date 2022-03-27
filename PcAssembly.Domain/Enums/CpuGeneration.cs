using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CpuGeneration
    {
        AMD=0,
        CoffeLake = 8,
        CoffeLakeRefresh = 9,
        CometLake = 10,
        RocketLake = 11,
        AlderLake = 12

    }
}
