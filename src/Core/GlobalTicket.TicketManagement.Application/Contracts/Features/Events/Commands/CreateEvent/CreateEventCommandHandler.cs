using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        
        var @event = mapper.Map<Event>(request);
        @event = await eventRepository.AddAsync(@event);

        return @event.EventId;
    }
}