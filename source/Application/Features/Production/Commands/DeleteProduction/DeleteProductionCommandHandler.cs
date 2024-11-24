using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteProduction;

public class DeleteProductionCommandHandler : IRequestHandler<DeleteProductionCommand, DeleteProductionCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IProductionRepository _ProductionRepository;

    public DeleteProductionCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IProductionRepository ProductionRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _ProductionRepository = ProductionRepository;
    }

    public async Task<DeleteProductionCommandResponse?> Handle(DeleteProductionCommand request, CancellationToken cancellationToken)
    {
        var Production = _ProductionRepository.Get(Production => Production.Id == request.Id);

        if (Production is null)
        {
            await _mediator.Publish(new DomainNotification("DeleteProduction", "Produção não encontrada"), cancellationToken);
            return default;
        }

        _ProductionRepository.Delete(Production);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("DeleteProduction", "Produção deletada com sucesso"), cancellationToken);
        var response = new DeleteProductionCommandResponse {};
        return response;    
    }
}