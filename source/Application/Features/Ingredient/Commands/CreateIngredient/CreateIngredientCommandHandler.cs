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

    public CreateIngredientCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;   
        _mediator = mediator;
        _ingredientRepository = ingredientRepository;
    }

    public async Task<CreateIngredientCommandResponse?> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {

        var existingIngredient = _ingredientRepository.Get(ingredient => ingredient.Name == request.Request.Name);

        if (existingIngredient is not null) {
            await _mediator.Publish(new DomainNotification("CreateIngredient", "Ingredient already exists"), cancellationToken);
            return default;
        }

        if (request.Request.Stock < request.Request.MinimumStock) {
            await _mediator.Publish(new DomainNotification("CreateIngredient", "Stock cannot be less than minimum stock"), cancellationToken);
            return default;
        }

        var ingredient = new Ingredient {
            Name = request.Request.Name,
            Measurement = request.Request.Measurement,
            Stock = request.Request.Stock,
            MinimumStock = request.Request.MinimumStock,
            UnitPrice = request.Request.UnitPrice
        };

        var insertionResult = _ingredientRepository.Add(ingredient);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("CreateIngredient", "Ingredient created successfully"), cancellationToken);

        var response = new CreateIngredientCommandResponse 
        {
            Id = insertionResult.Id,
            Name = insertionResult.Name,
            Measurement = insertionResult.Measurement,
            Stock = insertionResult.Stock,
            MinimumStock = insertionResult.MinimumStock,
            UnitPrice = insertionResult.UnitPrice
        };

        return response;    
    }
}