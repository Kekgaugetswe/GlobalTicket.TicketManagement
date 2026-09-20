using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Domain.Entities;

namespace GlobalTicket.TicketManagement.Persistence.Repositories;

public class OrderRepository(GlobalTicketDbContext dbContext) : BaseRepository<Order>(dbContext), IOrderRepository
{
    
}