using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateProduction;

public class CreateProductionCommandHandler : IRequestHandler<CreateProductionCommand, CreateProductionCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IProductionRepository _productionRepository;

    public CreateProductionCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IRecipeRepository recipeRepository,
        IIngredientRepository ingredientRepository,
        IProductionRepository productionRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _recipeRepository = recipeRepository;
        _ingredientRepository = ingredientRepository;
        _productionRepository = productionRepository;
    }

    public async Task<CreateProductionCommandResponse?> Handle(CreateProductionCommand request, CancellationToken cancellationToken)
    {
        var recipe = await _recipeRepository.GetWithIngredientsAsync(request.Request.ReceitaId);
        if (recipe == null)
        {
            await _mediator.Publish(new DomainNotification("CreateProduction", "Recipe not found"), cancellationToken);
            return null;
        }

        var production = new Production
        {
            ReceitaId = recipe.Id,
            QuantidadeProduzida = request.Request.QuantidadeProduzida,
            DataProducao = DateTime.UtcNow
        };
        await _productionRepository.AddAsync(production);

        _unitOfWork.Commit();

        var errorMessages = new List<string>();

        foreach (var ingredienteReceita in recipe.Ingredientes)
        {
            var ingrediente = await _ingredientRepository.GetAsync(i => i.Id == ingredienteReceita.IngredienteId);
            if (ingrediente == null)
            {
                errorMessages.Add($"Ingredient with ID {ingredienteReceita.IngredienteId} not found");
                continue;
            }

            var quantidadeDescontada = ingredienteReceita.QuantidadeNecessaria * request.Request.QuantidadeProduzida;

            if (ingrediente.Stock < quantidadeDescontada)
            {
                errorMessages.Add($"Insufficient stock for ingredient {ingrediente.Name}");
                continue;
            }

            ingrediente.Stock -= quantidadeDescontada;
            _ingredientRepository.Update(ingrediente);

            _unitOfWork.Commit();
        }

        if (errorMessages.Count > 0)
        {
            await _mediator.Publish(new DomainNotification("CreateProduction", string.Join(", ", errorMessages)), cancellationToken);
            return null;
        }

        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("CreateProduction", "Production created successfully and stock updated"), cancellationToken);

        return new CreateProductionCommandResponse
        {
            Id = production.Id,
            ReceitaId = production.ReceitaId,
            QuantidadeProduzida = production.QuantidadeProduzida,
            DataProducao = production.DataProducao
        };
    }
}
