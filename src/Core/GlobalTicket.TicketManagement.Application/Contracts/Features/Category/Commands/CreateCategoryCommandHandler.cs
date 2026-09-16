using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using MediatR;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Commands;

public class CreateCategoryCommandHandler(IAsyncRepository<Domain.Entities.Category> categoryRepository, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IAsyncRepository<Domain.Entities.Category> _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();

        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }
        
        throw new NotImplementedException();
    }
}