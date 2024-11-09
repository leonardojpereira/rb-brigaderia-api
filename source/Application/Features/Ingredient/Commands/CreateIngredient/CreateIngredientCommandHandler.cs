using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateIngredient;

public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, CreateIngredientCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IStockMovementRepository _stockMovementRepository;

    public CreateIngredientCommandHandler(
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

    public async Task<CreateIngredientCommandResponse?> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var existingIngredient = _ingredientRepository.Get(ingredient => ingredient.Name == request.Request.Name);

        if (existingIngredient is not null)
        {
            if (existingIngredient.IsDeleted)
            {
                existingIngredient.IsDeleted = false;
                existingIngredient.Stock = request.Request.Stock;
                existingIngredient.MinimumStock = request.Request.MinimumStock;
                existingIngredient.UnitPrice = request.Request.UnitPrice;
                existingIngredient.Measurement = request.Request.Measurement;

                _ingredientRepository.Update(existingIngredient);

                var stockMovement = new StockMovement
                {
                    IngredientId = existingIngredient.Id,
                    Quantity = request.Request.Stock,
                    Description = "Restaurado e adicionado ao estoque",
                    MovementType = "entrada",
                    CreatedAt = DateTime.UtcNow
                };
                await _stockMovementRepository.AddAsync(stockMovement);

                _unitOfWork.Commit();

                await _mediator.Publish(new DomainSuccessNotification("CreateIngredient", "Produto restaurado com sucesso!"), cancellationToken);

                return new CreateIngredientCommandResponse
                {
                    Id = existingIngredient.Id,
                    Name = existingIngredient.Name,
                    Measurement = existingIngredient.Measurement,
                    Stock = existingIngredient.Stock,
                    MinimumStock = existingIngredient.MinimumStock,
                    UnitPrice = existingIngredient.UnitPrice
                };
            }

            await _mediator.Publish(new DomainNotification("CreateIngredient", "Produto já existe"), cancellationToken);
            return default;
        }

        if (request.Request.Stock < request.Request.MinimumStock)
        {
            await _mediator.Publish(new DomainNotification("CreateIngredient", "A quantidade de estoque não pode ser menor que o estoque mínimo estabelecido"), cancellationToken);
            return default;
        }

        var ingredient = new Ingredient
        {
            Name = request.Request.Name,
            Measurement = request.Request.Measurement,
            Stock = request.Request.Stock,
            MinimumStock = request.Request.MinimumStock,
            UnitPrice = request.Request.UnitPrice
        };

        var insertionResult = _ingredientRepository.Add(ingredient);
        _unitOfWork.Commit();

        var newStockMovement = new StockMovement
        {
            IngredientId = insertionResult.Id,
            Quantity = request.Request.Stock,
            Description = "Estoque inicial",
            MovementType = "entrada",
            CreatedAt = DateTime.UtcNow
        };
        await _stockMovementRepository.AddAsync(newStockMovement);

        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("CreateIngredient", "Produto criado com sucesso!"), cancellationToken);

        return new CreateIngredientCommandResponse
        {
            Id = insertionResult.Id,
            Name = insertionResult.Name,
            Measurement = insertionResult.Measurement,
            Stock = insertionResult.Stock,
            MinimumStock = insertionResult.MinimumStock,
            UnitPrice = insertionResult.UnitPrice
        };
    }
}
