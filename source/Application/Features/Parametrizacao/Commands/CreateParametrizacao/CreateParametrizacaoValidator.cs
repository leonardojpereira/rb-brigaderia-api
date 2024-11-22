using FluentValidation;

namespace Project.Application.Features.Commands.CreateParametrizacao;

public class CreateParametrizacaoCommandValidator : AbstractValidator<CreateParametrizacaoCommand>
{
    public CreateParametrizacaoCommandValidator()
    {
        RuleFor(x => x.Request.NomeVendedor)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.PrecoCaixinha)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} não pode ser negativo.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.Custo)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} não pode ser negativo.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.Lucro)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} não pode ser negativo.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.LocalVenda)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.HorarioInicio)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.HorarioFim)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .GreaterThan(x => x.Request.HorarioInicio)
            .WithMessage("{PropertyName} deve ser maior que o Horário de Início.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.PrecisaPassagem)
            .NotNull().WithMessage("{PropertyName} é obrigatório.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.PrecoPassagem)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} não pode ser negativo.")
            .When(x => x.Request != null && x.Request.PrecisaPassagem == true);
    }
}
