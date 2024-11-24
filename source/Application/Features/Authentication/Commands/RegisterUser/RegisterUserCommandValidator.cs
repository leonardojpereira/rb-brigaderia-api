namespace Project.Application.Features.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull().WithMessage("{PropertyName} é obrigatório.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.Password)
                    .NotEmpty().WithMessage("Senha é obrigatório.")
                    .NotNull().WithMessage("Senha é obrigatório.")
                    .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.")
                    .Matches(@"[A-Z]").WithMessage("Senha deve conter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]").WithMessage("Senha deve conter pelo menos uma letra minúscula.")
                    .Matches(@"[0-9]").WithMessage("Senha deve conter pelo menos um número.")
                    .Matches(@"[^a-zA-Z0-9]").WithMessage("Senha deve conter pelo menos um caractere especial.");

                RuleFor(x => x.Request.Email)
                    .NotEmpty().WithMessage("E-mail é obrigatório.")
                    .NotNull().WithMessage("E-mail é obrigatório.")
                    .EmailAddress().WithMessage("E-mail é inválido.");
            });

        RuleFor(x => x.Request.RoleId)
            .NotEmpty().WithMessage("Tipo de perfil é obrigatório.")
            .NotNull().WithMessage("Tipo de perfil é obrigatório.");
    }
}
