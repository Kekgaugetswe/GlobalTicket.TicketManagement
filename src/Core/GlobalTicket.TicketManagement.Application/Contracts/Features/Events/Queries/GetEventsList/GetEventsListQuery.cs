using GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventsList;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
    
}