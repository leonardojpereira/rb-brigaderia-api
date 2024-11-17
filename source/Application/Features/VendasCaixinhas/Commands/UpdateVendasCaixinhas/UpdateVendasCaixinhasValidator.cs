using FluentValidation;

namespace Project.Application.Features.Commands.UpdateVendasCaixinhas
{
    public class UpdateVendasCaixinhasCommandValidator : AbstractValidator<UpdateVendasCaixinhasCommand>
    {
        public UpdateVendasCaixinhasCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.");
        }
    }
}
