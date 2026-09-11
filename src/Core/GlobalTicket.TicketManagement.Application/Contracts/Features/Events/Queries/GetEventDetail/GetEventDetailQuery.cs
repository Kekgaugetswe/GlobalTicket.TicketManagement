using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQuery : IRequest<EventDetailVm>
{
    public Guid Id { get; set; }
    
}