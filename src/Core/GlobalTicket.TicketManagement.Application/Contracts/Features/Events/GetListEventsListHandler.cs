using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events;

public class GetListEventsListHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IMapper _mapper = mapper;
    private readonly IAsyncRepository<Event>  _eventRepository = eventRepository;

    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
        return _mapper.Map<List<EventListVm>>(allEvents);
    }
}