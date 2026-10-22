using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;

namespace GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
}