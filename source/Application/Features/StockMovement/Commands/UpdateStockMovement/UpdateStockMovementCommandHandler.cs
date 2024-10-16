using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateStockMovement;

public class UpdateStockMovementCommandHandler : IRequestHandler<UpdateStockMovementCommand, UpdateStockMovementCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IStockMovementRepository _stockMovementRepository;
    private readonly IIngredientRepository _ingredientRepository;

    public UpdateStockMovementCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IStockMovementRepository stockMovementRepository,
        IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _stockMovementRepository = stockMovementRepository;
        _ingredientRepository = ingredientRepository;
    }

    public async Task<UpdateStockMovementCommandResponse?> Handle(UpdateStockMovementCommand request, CancellationToken cancellationToken)
{
    var dbIngredient = await _ingredientRepository.GetAsync(ingredient => ingredient.Id == request.Request.IngredientId);

    if (dbIngredient is null)
    {
        await _mediator.Publish(new DomainNotification("UpdateStockMovement", "Ingredient not found"), cancellationToken);
        return null;
    }

    // Ajustar o estoque com base no tipo de movimentação
    if (request.Request.MovementType == "entrada")
    {
        dbIngredient.Stock += request.Request.Quantity;
    }
    else if (request.Request.MovementType == "saida")
    {
        if (dbIngredient.Stock < request.Request.Quantity)
        {
            await _mediator.Publish(new DomainNotification("UpdateStockMovement", "Insufficient stock"), cancellationToken);
            return null;
        }
        dbIngredient.Stock -= request.Request.Quantity;
    }
    else
    {
        await _mediator.Publish(new DomainNotification("UpdateStockMovement", "Invalid movement type"), cancellationToken);
        return null;
    }

    // Criar a nova movimentação de estoque
    var newStockMovement = new StockMovement
    {
        Id = Guid.NewGuid(), // Gerar um novo ID para a movimentação
        IngredientId = dbIngredient.Id,
        Quantity = request.Request.Quantity,
        Description = request.Request.Description,
        MovementType = request.Request.MovementType,
        CreatedAt = DateTime.UtcNow
    };

    // Salvar a nova movimentação no banco
    await _stockMovementRepository.AddAsync(newStockMovement);

    // Atualizar o ingrediente
    _ingredientRepository.Update(dbIngredient);

    // Commitar as alterações
    _unitOfWork.Commit();

    await _mediator.Publish(new DomainSuccessNotification("UpdateStockMovement", "Stock updated successfully"), cancellationToken);

    // Retornar os dados da movimentação
    var response = new UpdateStockMovementCommandResponse
    {
        Id = newStockMovement.Id, // Retornar o ID da nova movimentação
        IngredientId = dbIngredient.Id,
        Quantity = request.Request.Quantity,
        Description = request.Request.Description, // Incluir a descrição
        MovementType = request.Request.MovementType
    };

    return response;
}


}
