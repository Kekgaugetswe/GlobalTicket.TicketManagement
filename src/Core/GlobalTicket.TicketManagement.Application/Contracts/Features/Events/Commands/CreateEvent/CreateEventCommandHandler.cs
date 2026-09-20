using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Infrastructure;
using GlobalTicket.TicketManagement.Application.Contracts.Models.Mail;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper, IEmailService emailService)
    : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        
        var @event = mapper.Map<Event>(request);
        var validator =  new CreateCommandEventValidator(eventRepository);
        
        var validationResult = await validator.ValidateAsync(request);
        if (validationResult.Errors.Count > 0)
            throw new Exceptions.ValidationException(validationResult);
        
        @event = await eventRepository.AddAsync(@event);
        var email = new Email() {To = "kekgaguetswe@gmail.com", Body = $"new event was created: {request}", Subject = "A new event was created"};
        
        //Sending email notification to admin Address
        try
        {
            await emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            // this should not stop the API from doing else so this can be logged
            
        }

        return @event.EventId;
    }
}