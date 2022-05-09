using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeComponent
    {
        CPU,
        GraphicCard,
        Motherboard,
        RAM,
        Cooler,
        PowerSupply
    }
}
