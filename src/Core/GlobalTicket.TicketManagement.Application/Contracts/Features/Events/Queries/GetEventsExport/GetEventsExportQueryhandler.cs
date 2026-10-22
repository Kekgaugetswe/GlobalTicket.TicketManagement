using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsExport;

public class GetEventsExportQueryhandler(IAsyncRepository<Event> eventRepository, IMapper mapper, ICsvExporter csvExporter) :IRequestHandler<GetEventsExportQuery, EventExportFileVm>
{
    public async Task<EventExportFileVm> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
    {
        var allEvent = mapper.Map<List<EventExportDto>>((await eventRepository.ListAllAsync()).OrderBy(x => x.Date));

        var fileData = csvExporter.ExportEventsToCsv(allEvent);
        var eventExportFileDto = new EventExportFileVm() { ContentType = "text/csv", Data = fileData, EventExportFileName = $"{Guid.NewGuid()}.csv"};
        return eventExportFileDto;

    }
}