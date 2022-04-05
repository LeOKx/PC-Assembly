using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SgRamType
    {
        GDDR1,
        GDDR2,
        GDDR3,
        GDDR4,
        GDDR5,
        GDDR5X,
        GDDR6,
        GDDR6X,
    }
}
