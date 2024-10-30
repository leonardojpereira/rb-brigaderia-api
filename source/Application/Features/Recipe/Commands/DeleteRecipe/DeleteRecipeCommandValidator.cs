namespace Project.Application.Features.Commands.DeleteRecipe;

public class DeleteRecipeCommandValidator : AbstractValidator<DeleteRecipeCommand>
{
    public DeleteRecipeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
