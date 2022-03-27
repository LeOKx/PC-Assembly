using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CpuFamily
    {
        Core_i3,
        Core_i5,
        Core_i7,
        Core_i9,
        Ryzen_3,
        Ryzen_5,
        Ryzen_7,
        Ryzen_9,

    }
}
