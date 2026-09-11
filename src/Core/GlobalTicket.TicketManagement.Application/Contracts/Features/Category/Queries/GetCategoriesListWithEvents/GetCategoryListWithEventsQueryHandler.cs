using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesListWithevents;

public class GetCategoryListWithEventsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    : IRequestHandler<GetCategoriesListwithEventsQuery, List<CategoryEventListVm>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListwithEventsQuery request, CancellationToken cancellationToken)
    {
        var list = await _categoryRepository.GetCategoryiesWithEvents(request.HistoryEvents);
        throw new NotImplementedException();
    }
}