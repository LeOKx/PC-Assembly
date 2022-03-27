using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Company
    {
        Nvidia,
        Intel,
        AMD
    }
}
