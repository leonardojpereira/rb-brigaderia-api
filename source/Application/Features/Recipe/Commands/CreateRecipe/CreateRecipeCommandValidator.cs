namespace Project.Application.Features.Commands.CreateRecipe;

public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(x => x.Request.Nome)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleForEach(x => x.Request.Ingredientes)
            .ChildRules(ingrediente =>
            {
                ingrediente.RuleFor(i => i.IngredienteId)
                    .NotEmpty().WithMessage("Ingredient ID is required.");

                ingrediente.RuleFor(i => i.QuantidadeNecessaria)
                    .GreaterThan(0).WithMessage("QuantidadeNecessaria should be greater than 0.");
            });
    }
}
