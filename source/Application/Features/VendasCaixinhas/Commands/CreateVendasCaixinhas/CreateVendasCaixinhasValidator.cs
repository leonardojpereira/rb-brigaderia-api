using FluentValidation;

namespace Project.Application.Features.Commands.CreateVendasCaixinhas;

public class CreateVendasCaixinhasCommandValidator : AbstractValidator<CreateVendasCaixinhasCommand>
{
    public CreateVendasCaixinhasCommandValidator()
    {
        RuleFor(x => x.Request.DataVenda)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.QuantidadeCaixinhas)
            .GreaterThan(0).WithMessage("A {PropertyName} deve ser maior que zero.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.PrecoTotalVenda)
            .GreaterThan(0).WithMessage("O {PropertyName} deve ser maior que zero.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.Salario)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} não pode ser negativo.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.CustoTotal)
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

        RuleFor(x => x.Request.NomeVendedor)
            .NotEmpty().WithMessage("{PropertyName} é obrigatório.")
            .MaximumLength(100).WithMessage("{PropertyName} não pode ter mais que 100 caracteres.")
            .When(x => x.Request != null);
    }
}
