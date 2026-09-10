using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events;

public class GetEventsListQuery : IRequest<List<EventListVm>>
{
    
}