using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Queries.GetCategoriesList;

public class GetCategoriesListQueryHandler(
    IAsyncRepository<Domain.Entities.Category> categoryRepository,
    IMapper mapper)
    : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
{

    public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
    {
        var allCateorgies = (await categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
        return mapper.Map<List<CategoryListVm>>(allCateorgies);
    }
    
}