using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateIngredient;

public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, UpdateIngredientCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IStockMovementRepository _stockMovementRepository;

    public UpdateIngredientCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IIngredientRepository ingredientRepository,
        IStockMovementRepository stockMovementRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _ingredientRepository = ingredientRepository;
        _stockMovementRepository = stockMovementRepository;
    }

    public async Task<UpdateIngredientCommandResponse?> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        var dbIngredient = _ingredientRepository.Get(ingredient => ingredient.Id == request.Id);

        if (dbIngredient is null)
        {
            await _mediator.Publish(new DomainNotification("UpdateIngredient", "Produto não encontrado"), cancellationToken);
            return default;
        }

        var previousStock = dbIngredient.Stock;

        dbIngredient.Name = request.Request.Name ?? dbIngredient.Name;
        dbIngredient.Measurement = request.Request.Measurement ?? dbIngredient.Measurement;
        dbIngredient.Stock = request.Request.Stock ?? dbIngredient.Stock;
        dbIngredient.MinimumStock = request.Request.MinimumStock ?? dbIngredient.MinimumStock;
        dbIngredient.UnitPrice = request.Request.UnitPrice ?? dbIngredient.UnitPrice;
        dbIngredient.UpdatedAt = DateTime.UtcNow;

        var updateResult = _ingredientRepository.Update(dbIngredient);

        if (request.Request.Stock.HasValue && request.Request.Stock.Value != previousStock)
        {
            var movementType = request.Request.Stock > previousStock ? "entrada" : "saida";
            var quantityDifference = Math.Abs(request.Request.Stock.Value - previousStock);

            var stockMovement = new StockMovement
            {
                IngredientId = dbIngredient.Id,
                Quantity = quantityDifference,
                Description = "Atualização de estoque",
                MovementType = movementType,
                CreatedAt = DateTime.UtcNow
            };

            await _stockMovementRepository.AddAsync(stockMovement);
        }

        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("UpdateIngredient", "Produto atualizado com sucesso."), cancellationToken);

        var response = new UpdateIngredientCommandResponse
        {
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
