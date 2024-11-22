using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _userRepository = userRepository;
    }

    public async Task<DeleteUserCommandResponse?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
        {
            await _mediator.Publish(new DomainNotification("DeleteUser", "Usuário não encontrado"), cancellationToken);
            return default;
        }

        try
        {
            _userRepository.Delete(user);
             _unitOfWork.Commit();

            await _mediator.Publish(new DomainSuccessNotification("DeleteUser", "Usuário deletado com sucesso!"), cancellationToken);
            return new DeleteUserCommandResponse();
        }
        catch (Exception ex)
        {
            await _mediator.Publish(new DomainNotification("DeleteUser", $"Ocorreu um erro: {ex.Message}"), cancellationToken);
            return default;
        }
    }

}
