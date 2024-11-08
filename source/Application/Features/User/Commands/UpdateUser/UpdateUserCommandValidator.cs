using FluentValidation;

namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Request.Nome)
                .NotEmpty().WithMessage("Nome is required.");

            RuleFor(x => x.Request.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is invalid.");

            RuleFor(x => x.Request.RoleId)
                .NotEmpty().WithMessage("RoleId is required.");
        }
    }
}
