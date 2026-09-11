using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;

public class GetCategoriesListwithEventsQuery : IRequest<List<CategoryEventListVm>>
{
    public bool HistoryEvents { get; set; }
}