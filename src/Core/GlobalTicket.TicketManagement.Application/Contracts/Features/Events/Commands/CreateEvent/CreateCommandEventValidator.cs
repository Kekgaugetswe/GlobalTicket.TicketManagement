using FluentValidation;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;

public class CreateCommandEventValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    public CreateCommandEventValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
        RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is required").NotNull().MaximumLength(50).WithMessage("{Property} must not exceed 50 characters");
        RuleFor(p => p.Date).NotEmpty().WithMessage("{PropertyName} is required").GreaterThan(DateTime.Now);
        
        RuleFor(e=> e).MustAsync(EventNameAndDateUnique).WithErrorCode("An event with the same name already exists");
        RuleFor(p => p.Price).NotEmpty().WithMessage("{PropertyName} is required").GreaterThan(0);
    }
    
    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
    {
        return !(await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date));

    }
}