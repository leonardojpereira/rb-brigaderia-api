namespace Project.Application.Features.Commands.UpdateStockMovement;

public class UpdateStockMovementCommandValidator : AbstractValidator<UpdateStockMovementCommand>
{
    public UpdateStockMovementCommandValidator()
    {
        RuleFor(x => x.Request.IngredientId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.Quantity)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(x => x.Request.MovementType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .Must(x => x == "entrada" || x == "saida").WithMessage("{PropertyName} must be 'entrada' or 'saida'.");
    }
}
