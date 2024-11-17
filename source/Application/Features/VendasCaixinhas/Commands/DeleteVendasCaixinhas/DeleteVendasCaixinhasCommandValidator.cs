using Project.Application.Features.Commands.DeleteVendasCaixinhas;

namespace Project.Application.Features.Commands.DeletedVendasCaixinhas;

public class DeletedVendasCaixinhasCommandValidator : AbstractValidator<DeleteVendasCaixinhasCommand>
{
    public DeletedVendasCaixinhasCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
