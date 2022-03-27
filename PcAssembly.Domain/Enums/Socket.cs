using System.Text.Json.Serialization;

namespace PcAssembly.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Socket
    {
        Socket_1150,
        Socket_1151,
        Socket_1200,
        Socket_1151_V2,
        Socket_1700,
        Socket_AM4,
        Socket_AM3,

    }
}
