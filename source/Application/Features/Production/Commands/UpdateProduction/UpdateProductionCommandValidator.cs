using FluentValidation;

namespace Project.Application.Features.Commands.UpdateProduction
{
    public class UpdateProductionCommandValidator : AbstractValidator<UpdateProductionCommand>
    {
        public UpdateProductionCommandValidator()
        {
            RuleFor(x => x.Request.ReceitaId)
                .NotEmpty().WithMessage("Recipe ID is required.");

            RuleFor(x => x.Request.QuantidadeProduzida)
                .GreaterThan(0).WithMessage("The produced quantity must be greater than zero.");
        }
    }
}
