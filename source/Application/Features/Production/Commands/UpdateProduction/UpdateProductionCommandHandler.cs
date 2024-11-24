using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.UpdateProduction
{
    public class UpdateProductionCommandHandler : IRequestHandler<UpdateProductionCommand, UpdateProductionCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IProductionRepository _productionRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public UpdateProductionCommandHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IProductionRepository productionRepository,
            IRecipeRepository recipeRepository,
            IIngredientRepository ingredientRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _productionRepository = productionRepository;
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<UpdateProductionCommandResponse?> Handle(UpdateProductionCommand request, CancellationToken cancellationToken)
        {
            var production = await _productionRepository.GetAsync(p => p.Id == request.Id);
            if (production == null)
            {
                await _mediator.Publish(new DomainNotification("UpdateProduction", "Produção não encontrada."), cancellationToken);
                return null;
            }

            if (production.ReceitaId != request.Request.ReceitaId)
            {
                var recipe = await _recipeRepository.GetWithIngredientsAsync(request.Request.ReceitaId);
                if (recipe == null)
                {
                    await _mediator.Publish(new DomainNotification("UpdateProduction", "Receita não encontrada."), cancellationToken);
                    return null;
                }

                production.ReceitaId = recipe.Id;
            }

            production.QuantidadeProduzida = request.Request.QuantidadeProduzida;

            var recipeWithIngredients = await _recipeRepository.GetWithIngredientsAsync(production.ReceitaId);
            if (recipeWithIngredients == null)
            {
                await _mediator.Publish(new DomainNotification("UpdateProduction", "Receita não encontrada"), cancellationToken);
                return null;
            }

            foreach (var ingredienteReceita in recipeWithIngredients.Ingredientes)
            {
                var ingrediente = await _ingredientRepository.GetAsync(i => i.Id == ingredienteReceita.IngredienteId);
                if (ingrediente == null)
                {
                    await _mediator.Publish(new DomainNotification("UpdateProduction", $"Ingredient with ID {ingredienteReceita.IngredienteId} not found"), cancellationToken);
                    return null;
                }

                var quantidadeDescontada = ingredienteReceita.QuantidadeNecessaria * production.QuantidadeProduzida;

                if (ingrediente.Stock < quantidadeDescontada)
                {
                    await _mediator.Publish(new DomainNotification("UpdateProduction", $"Estoque insuficiente para {ingrediente.Name}"), cancellationToken);
                    return null;
                }

                ingrediente.Stock -= quantidadeDescontada;
                _ingredientRepository.Update(ingrediente);
            }

            _productionRepository.Update(production);
            _unitOfWork.Commit();

            await _mediator.Publish(new DomainSuccessNotification("UpdateProduction", "Produção atualizada com sucesso."), cancellationToken);

            return new UpdateProductionCommandResponse
            {
                ReceitaId = production.ReceitaId,
                QuantidadeProduzida = production.QuantidadeProduzida,
                DataAtualizada = DateTime.UtcNow
            };
        }
    }
}
