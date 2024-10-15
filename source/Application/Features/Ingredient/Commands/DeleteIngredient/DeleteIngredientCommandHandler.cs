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
        var ingredient = _ingredientRepository.Get(ingredient => ingredient.Id == request.Id);

        if (ingredient is null)
        {
            await _mediator.Publish(new DomainNotification("DeleteIngredient", "Ingredient not found"), cancellationToken);
            return default;
        }

        _ingredientRepository.Delete(ingredient);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("DeleteIngredient", "Ingredient deleted successfully"), cancellationToken);
        var response = new DeleteIngredientCommandResponse {};
        return response;    
    }
}