using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.DeleteIngredient;

public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, DeleteIngredientCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IIngredientRepository _ingredientRepository;

    public DeleteIngredientCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _ingredientRepository = ingredientRepository;
    }

 public async Task<DeleteIngredientCommandResponse?> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
{
    var ingredient = await _ingredientRepository.GetAsync(i => i.Id == request.Id);

    if (ingredient is null)
    {
        await _mediator.Publish(new DomainNotification("DeleteIngredient", "Ingredient not found"), cancellationToken);
        return default;
    }

    _ingredientRepository.DeleteSoft(ingredient);
    _unitOfWork.Commit();

    await _mediator.Publish(new DomainSuccessNotification("DeleteIngredient", "Ingredient marked as deleted successfully"), cancellationToken);
    return new DeleteIngredientCommandResponse();
}


}