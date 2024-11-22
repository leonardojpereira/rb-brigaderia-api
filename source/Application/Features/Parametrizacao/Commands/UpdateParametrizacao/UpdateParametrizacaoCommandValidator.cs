using FluentValidation;

namespace Project.Application.Features.Commands.UpdateParametrizacao;

public class UpdateParametrizacaoCommandValidator : AbstractValidator<UpdateParametrizacaoCommand>
{
    public UpdateParametrizacaoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.");
    }
}
