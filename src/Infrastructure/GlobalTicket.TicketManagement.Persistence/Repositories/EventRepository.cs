using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Persistence.Repositories;

public class EventRepository(GlobalTicketDbContext dbContext) :BaseRepository<Event>(dbContext), IEventRepository
{
    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        var maches = _dbContext.Events.Any(e=>e.Name == name && e.Date.Date.Equals(eventDate.Date));
        
        return Task.FromResult(maches); 
    }
}