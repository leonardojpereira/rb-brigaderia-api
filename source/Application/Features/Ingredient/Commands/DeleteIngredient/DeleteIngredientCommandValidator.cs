namespace Project.Application.Features.Commands.DeleteIngredient;

public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
{
    public DeleteIngredientCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
