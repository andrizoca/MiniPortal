using System.Text.Json.Serialization;

namespace MiniPortal.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TicketStatus
    {
        Open,
        InProgress,
        Acceptance,
        Closed,
        ClosedDuoToNoResponse
    }
}