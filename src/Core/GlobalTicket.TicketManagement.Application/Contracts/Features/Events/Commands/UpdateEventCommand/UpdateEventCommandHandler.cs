using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.UpdateEventCommand;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;

    public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var updateToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
        _mapper.Map(request, updateToUpdate, typeof(UpdateEventCommand), typeof(Event));
        await _eventRepository.UpdateAsync(updateToUpdate);
    }
}