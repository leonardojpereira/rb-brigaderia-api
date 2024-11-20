using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteParametrizacao;

public class DeleteParametrizacaoCommandHandler : IRequestHandler<DeleteParametrizacaoCommand, DeleteParametrizacaoCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IParametrizacaoRepository _ParametrizacaoRepository;

    public DeleteParametrizacaoCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IParametrizacaoRepository ParametrizacaoRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _ParametrizacaoRepository = ParametrizacaoRepository;
    }

 public async Task<DeleteParametrizacaoCommandResponse?> Handle(DeleteParametrizacaoCommand request, CancellationToken cancellationToken)
{

    var Parametrizacao = await _ParametrizacaoRepository.GetByIdAsync(request.Id, cancellationToken);

    if (Parametrizacao is null)
    {
        await _mediator.Publish(new DomainNotification("DeleteParametrizacao", "Parametrizacao not found"), cancellationToken);
        return default;
    }

    _ParametrizacaoRepository.DeleteSoft(Parametrizacao);
    _unitOfWork.Commit();

    await _mediator.Publish(new DomainSuccessNotification("DeleteParametrizacao", "Parametrizacao marked as deleted successfully"), cancellationToken);
    return new DeleteParametrizacaoCommandResponse();
}


}