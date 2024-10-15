using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateIngredient;

public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, UpdateIngredientCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IIngredientRepository _ingredientRepository;
    public UpdateIngredientCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _ingredientRepository = ingredientRepository;
    }

    public async Task<UpdateIngredientCommandResponse?> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {

        var dbIngredient = _ingredientRepository.Get(ingredient => ingredient.Id == request.Id);
        
        if (dbIngredient is null)
        {
            await _mediator.Publish(new DomainNotification("UpdateIngredient", "Ingredient not found"), cancellationToken);
            return default;
        }

        dbIngredient.Name = request.Request.Name ?? dbIngredient.Name;
        dbIngredient.Measurement = request.Request.Measurement ?? dbIngredient.Measurement;
        dbIngredient.Stock = request.Request.Stock ?? dbIngredient.Stock;
        dbIngredient.MinimumStock = request.Request.MinimumStock ?? dbIngredient.MinimumStock;
        dbIngredient.UnitPrice = request.Request.UnitPrice ?? dbIngredient.UnitPrice;
        dbIngredient.UpdatedAt = DateTime.UtcNow;

        var updateResult = _ingredientRepository.Update(dbIngredient);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("UpdateIngredient", "Ingredient updated successfully"), cancellationToken);
        var response = new UpdateIngredientCommandResponse {
            Id = updateResult.Id,
            Name = updateResult.Name,
            Measurement = updateResult.Measurement,
            Stock = updateResult.Stock,
            MinimumStock = updateResult.MinimumStock,
            UnitPrice = updateResult.UnitPrice
        };
        return response;    
    }
}