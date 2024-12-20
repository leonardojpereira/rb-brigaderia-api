﻿using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllIngredients
{
    public class GetAllIngredientsQueryHandler : IRequestHandler<GetAllIngredientsQuery, GetAllIngredientsQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IIngredientRepository _ingredientRepository;

        public GetAllIngredientsQueryHandler(IMediator mediator, IIngredientRepository ingredientRepository)
        {
            _mediator = mediator;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<GetAllIngredientsQueryResponse?> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
        {
            var filteredIngredients = string.IsNullOrEmpty(request.Filter)
                ? await _ingredientRepository.GetAllAsync(cancellationToken)
                : await _ingredientRepository.GetByFilterAsync(request.Filter, cancellationToken);

            var totalIngredients = filteredIngredients.Count();

            var dbIngredients = filteredIngredients
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var ingredientDTOs = dbIngredients
                .Select(dbIngredient => new GetAllIngredientsIngredientDTO
                {
                    Id = dbIngredient.Id,
                    Name = dbIngredient.Name,
                    Measurement = dbIngredient.Measurement,
                    Stock = dbIngredient.Stock,
                    MinimumStock = dbIngredient.MinimumStock,
                    UnitPrice = dbIngredient.UnitPrice,
                    CreatedAt = dbIngredient.CreatedAt,
                    UpdatedAt = dbIngredient.UpdatedAt
                })
                .ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllIngredients", "Ingredients retrieved successfully"), cancellationToken);

            return new GetAllIngredientsQueryResponse 
            { 
                Ingredients = ingredientDTOs,
                TotalItems = totalIngredients,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
