using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler(
    IAsyncRepository<Event> _eventRepository,
    IAsyncRepository<Domain.Entities.Category> _categoryRepository,
    IMapper _mapper)
    : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
    

    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        
        var @event = await _eventRepository.GetByIdAsync(request.Id);
        var eventDetailDto = _mapper.Map<EventDetailVm>(@event);
        var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);
        eventDetailDto.Category = _mapper.Map<CategoryDto>(category);
        return eventDetailDto;
    }
}