using FluentValidation;

namespace Project.Application.Features.Commands.CreateProduction
{
    public class CreateProductionCommandValidator : AbstractValidator<CreateProductionCommand>
    {
        public CreateProductionCommandValidator()
        {
            RuleFor(x => x.Request.ReceitaId)
                .NotEmpty().WithMessage("ReceitaId is required.");

            RuleFor(x => x.Request.QuantidadeProduzida)
                .GreaterThan(0).WithMessage("QuantidadeProduzida must be greater than zero.");

            RuleFor(x => x.Request.DataProducao)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("DataProducao must be a past or current date.");
        }
    }
}
