using FluentValidation;

namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} é obrigatório.");

            RuleFor(x => x.Request.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.");

            RuleFor(x => x.Request.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(x => x.Request.RoleId)
                .NotEmpty().WithMessage("Tipo de perfil é obrigatório.");
        }
    }
}
