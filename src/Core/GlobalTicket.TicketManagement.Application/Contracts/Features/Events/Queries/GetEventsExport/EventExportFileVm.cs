namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;

public class EventExportFileVm
{
    public string EventExportFileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public byte[]? Data { get; set; }
}