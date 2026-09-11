namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;

public class CategoryEventListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<CategoryEventDto> Events { get; set; }
}