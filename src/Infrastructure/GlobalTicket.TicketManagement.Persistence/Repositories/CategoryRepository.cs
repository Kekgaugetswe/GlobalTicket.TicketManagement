using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagement.Persistence.Repositories;

public class CategoryRepository(GlobalTicketDbContext dbContext) : BaseRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<List<Category>> GetCategoryiesWithEvents(bool includePassedEvents)
    {
        var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
        if (!includePassedEvents)
        {
            allCategories.ForEach(p => p.Events.ToList().All(c=>c.Date < DateTime.Today));
        }
        return allCategories;
    }
}