using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResponse?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (dbUser is null)
            {
                await _mediator.Publish(new DomainNotification("UpdateUser", "Usuário não encontrado."), cancellationToken);
                return default;
            }

            dbUser.Nome = request.Request.Nome ?? dbUser.Nome;
            dbUser.Email = request.Request.Email ?? dbUser.Email;
            dbUser.RoleId = request.Request.RoleId != Guid.Empty ? request.Request.RoleId : dbUser.RoleId;

            var updateResult = _userRepository.Update(dbUser);
            _unitOfWork.Commit();

            await _mediator.Publish(new DomainSuccessNotification("UpdateUser", "Usuário atualizado com sucesso!"), cancellationToken);

            return new UpdateUserCommandResponse
            {
                Id = updateResult.Id,
                Nome = updateResult.Nome,
                Email = updateResult.Email
            };
        }
    }
}
