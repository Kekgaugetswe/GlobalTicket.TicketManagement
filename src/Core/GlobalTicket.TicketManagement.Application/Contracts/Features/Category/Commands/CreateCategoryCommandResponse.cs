using GlobalTicket.TicketManagement.Application.Contracts.Responses;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Commands;

public class CreateCategoryCommandResponse :BaseResponse
{
    public CreateCategoryCommandResponse(): base()
    {
        
    }

    public CreateCategoryDto category { get; set; } = default!;
}