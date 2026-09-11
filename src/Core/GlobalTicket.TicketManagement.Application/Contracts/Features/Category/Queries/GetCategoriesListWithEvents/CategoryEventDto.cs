namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;

public class CategoryEventDto
{
   public Guid EventId { get; set; }
   public string Name { get; set; } = String.Empty;
   public int Price { get; set; }
   public string Artist { get; set; }
   public DateTime Date { get; set; }
   public Guid CategoryId { get; set; }
   
}