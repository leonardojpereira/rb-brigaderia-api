namespace Project.Application.Features.Commands.CreateIngredient;

public class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator()
    {
        RuleFor(x => x.Request.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.Measurement)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.Stock)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.MinimumStock)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.UnitPrice)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}