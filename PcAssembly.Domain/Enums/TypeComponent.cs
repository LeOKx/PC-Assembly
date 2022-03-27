using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeComponent
    {
        GraphicCard,
        CPU,
        RAM,
        Motherboard,
        Cooler,
        PowerSupply
    }
}
