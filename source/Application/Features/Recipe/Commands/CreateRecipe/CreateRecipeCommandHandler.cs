using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.CreateRecipe;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, CreateRecipeCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientRepository _ingredientRepository;

    public CreateRecipeCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _recipeRepository = recipeRepository;
        _ingredientRepository = ingredientRepository;
    }

    public async Task<CreateRecipeCommandResponse?> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var existingRecipe = _recipeRepository.Get(recipe => recipe.Nome == request.Request.Nome);

        if (existingRecipe is not null)
        {
            await _mediator.Publish(new DomainNotification("CreateRecipe", "Receita já existe"), cancellationToken);
            return default;
        }

        var recipe = new Recipe
        {
            Nome = request.Request.Nome,
            Descricao = request.Request.Descricao,
            Ingredientes = request.Request.Ingredientes.Select(i => new RecipeIngredient
            {
                IngredienteId = i.IngredienteId,
                QuantidadeNecessaria = i.QuantidadeNecessaria
            }).ToList()
        };

        var insertionResult = _recipeRepository.Add(recipe);
        _unitOfWork.Commit();

        var response = new CreateRecipeCommandResponse
        {
            Id = insertionResult.Id,
            Nome = insertionResult.Nome,
            Descricao = insertionResult.Descricao,
            Ingredientes = insertionResult.Ingredientes.Select(i =>
            {
                var ingrediente = _ingredientRepository.Get(ing => ing.Id == i.IngredienteId);
                return new CreateRecipeCommandResponse.CreateIngredienteQuantidadeResponse
                {
                    IngredienteId = i.IngredienteId,
                    QuantidadeNecessaria = i.QuantidadeNecessaria,
                    Nome = ingrediente?.Name ?? "Desconhecido"
                };
            }).ToList()
        };

        await _mediator.Publish(new DomainSuccessNotification("CreateRecipe", "Receita cadastrada com sucesso!"), cancellationToken);

        return response;
    }
}
