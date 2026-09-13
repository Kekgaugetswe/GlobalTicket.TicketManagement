using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.DeleteEventCommand;

public class DeleteEventCommand : IRequest
{
    public Guid EventId { get; set; }
}