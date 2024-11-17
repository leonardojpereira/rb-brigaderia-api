using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteVendasCaixinhas;

public class DeleteVendasCaixinhasCommandHandler : IRequestHandler<DeleteVendasCaixinhasCommand, DeleteVendasCaixinhasCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IVendasCaixinhasRepository _VendasCaixinhasRepository;

    public DeleteVendasCaixinhasCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IVendasCaixinhasRepository VendasCaixinhasRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _VendasCaixinhasRepository = VendasCaixinhasRepository;
    }

 public async Task<DeleteVendasCaixinhasCommandResponse?> Handle(DeleteVendasCaixinhasCommand request, CancellationToken cancellationToken)
{
    var VendasCaixinhas = await _VendasCaixinhasRepository.GetAsync(i => i.Id == request.Id);

    if (VendasCaixinhas is null)
    {
        await _mediator.Publish(new DomainNotification("DeleteVendasCaixinhas", "VendasCaixinhas not found"), cancellationToken);
        return default;
    }

    _VendasCaixinhasRepository.DeleteSoft(VendasCaixinhas);
    _unitOfWork.Commit();

    await _mediator.Publish(new DomainSuccessNotification("DeleteVendasCaixinhas", "VendasCaixinhas marked as deleted successfully"), cancellationToken);
    return new DeleteVendasCaixinhasCommandResponse();
}


}