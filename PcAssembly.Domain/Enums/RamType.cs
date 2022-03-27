using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RamType
    {
        DDR1,
        DDR2,
        DDR3,
        DDR4,
        DDR5
    }
}
