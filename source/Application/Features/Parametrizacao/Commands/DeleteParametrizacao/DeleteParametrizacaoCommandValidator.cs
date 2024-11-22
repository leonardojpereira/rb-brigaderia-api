using Project.Application.Features.Commands.DeleteVendasCaixinhas;

namespace Project.Application.Features.Commands.DeleteParametrizacao;

public class DeleteParametrizacaoCommandValidator : AbstractValidator<DeleteVendasCaixinhasCommand>
{
    public DeleteParametrizacaoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
