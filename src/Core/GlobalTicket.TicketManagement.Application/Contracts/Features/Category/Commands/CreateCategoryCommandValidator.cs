using FluentValidation;

namespace GlobalTicket.TicketManagement.Application.Contracts.Features.Category.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{

    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
    }
}