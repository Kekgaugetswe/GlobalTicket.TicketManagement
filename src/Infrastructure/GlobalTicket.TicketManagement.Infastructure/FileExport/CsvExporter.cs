using CsvHelper;
using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;

namespace GlobalTicket.TicketManagement.Infastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter);
            csvWriter.WriteRecords(eventExportDtos);
            
        }
        return memoryStream.ToArray();
    }
}