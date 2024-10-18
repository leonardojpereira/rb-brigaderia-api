using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, UpdateRecipeCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;
    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeIngredientRepository _recipeIngredientRepository;
    private readonly IIngredientRepository _ingredientRepository;

    public UpdateRecipeCommandHandler(
        IUnitOfWork unitOfWork,
        IMediator mediator,
        IRecipeRepository recipeRepository,
        IRecipeIngredientRepository recipeIngredientRepository,
        IIngredientRepository ingredientRepository)
    {
        _unitOfWork = unitOfWork;
        _mediator = mediator;
        _recipeRepository = recipeRepository;
        _recipeIngredientRepository = recipeIngredientRepository;
        _ingredientRepository = ingredientRepository;
    }

    public async Task<UpdateRecipeCommandResponse?> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var dbRecipe = await _recipeRepository.GetAsync(recipe => recipe.Id == request.Id);
        if (dbRecipe == null)
        {
            await _mediator.Publish(new DomainNotification("UpdateRecipe", "Recipe not found"), cancellationToken);
            return null;
        }

        dbRecipe.Nome = request.Request.Nome ?? dbRecipe.Nome;
        dbRecipe.Descricao = request.Request.Descricao ?? dbRecipe.Descricao;

        var existingIngredients = await _recipeIngredientRepository.GetAllByRecipeId(dbRecipe.Id);
        foreach (var ingredient in existingIngredients)
        {
            _recipeIngredientRepository.Remove(ingredient);
        }

        _unitOfWork.Commit();

        foreach (var newIngredient in request.Request.Ingredientes)
        {
            var ingrediente = await _ingredientRepository.GetAsync(ing => ing.Id == newIngredient.IngredienteId);
            if (ingrediente == null)
            {
                await _mediator.Publish(new DomainNotification("UpdateRecipe", $"Ingredient with ID {newIngredient.IngredienteId} not found"), cancellationToken);
                return null;
            }

            var recipeIngredient = new RecipeIngredient
            {
                IngredienteId = newIngredient.IngredienteId,
                QuantidadeNecessaria = newIngredient.QuantidadeNecessaria,
                RecipeId = dbRecipe.Id
            };

            await _recipeIngredientRepository.AddAsync(recipeIngredient);
        }

        _recipeRepository.Update(dbRecipe);
        _unitOfWork.Commit();

        await _mediator.Publish(new DomainSuccessNotification("UpdateRecipe", "Recipe updated successfully"), cancellationToken);

        var response = new UpdateRecipeCommandResponse
        {
            Id = dbRecipe.Id,
            Nome = dbRecipe.Nome,
            Descricao = dbRecipe.Descricao,
            Ingredientes = request.Request.Ingredientes.Select(i =>
            {
                var ingrediente = _ingredientRepository.Get(ing => ing.Id == i.IngredienteId);
                return new UpdateRecipeCommandResponse.UpdateRecipeIngredientResponse
                {
                    IngredienteId = i.IngredienteId,
                    QuantidadeNecessaria = i.QuantidadeNecessaria,
                    Nome = ingrediente?.Name ?? "Desconhecido"
                };
            }).ToList()
        };

        return response;
    }
}
