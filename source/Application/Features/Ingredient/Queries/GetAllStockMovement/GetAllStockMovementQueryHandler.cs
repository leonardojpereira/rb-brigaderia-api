using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllStockMovement
{
    public class GetAllStockMovementQueryHandler : IRequestHandler<GetAllStockMovementQuery, GetAllStockMovementQueryResponse>
    {
        private readonly IStockMovementRepository _stockMovementRepository;

        public GetAllStockMovementQueryHandler(IStockMovementRepository stockMovementRepository)
        {
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<GetAllStockMovementQueryResponse> Handle(GetAllStockMovementQuery request, CancellationToken cancellationToken)
        {
            var dbStockMovements = await _stockMovementRepository.GetAllAsync();

            var dataInicial = request.DataInicial?.Date;
            var dataFinal = request.DataFinal?.Date.AddDays(1).AddSeconds(-1);

            var filteredMovements = dbStockMovements
                .Where(m => (!dataInicial.HasValue || m.CreatedAt >= dataInicial.Value)
                         && (!dataFinal.HasValue || m.CreatedAt <= dataFinal.Value))
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            var ingredientStockMap = new Dictionary<Guid, decimal>();

            var stockMovementDTOs = filteredMovements
                .Select(dbStockMovement =>
                {
                    if (!ingredientStockMap.TryGetValue(dbStockMovement.IngredientId, out var currentStock))
                    {
                        currentStock = dbStockMovement.Ingredient.Stock - (dbStockMovement.MovementType == "entrada" ? dbStockMovement.Quantity : -dbStockMovement.Quantity);
                    }

                    currentStock += dbStockMovement.MovementType == "entrada"
                        ? dbStockMovement.Quantity
                        : -dbStockMovement.Quantity;

                    ingredientStockMap[dbStockMovement.IngredientId] = currentStock;

                    return new GetAllStockMovementDTO
                    {
                        Id = dbStockMovement.Id,
                        IngredientId = dbStockMovement.IngredientId,
                        Ingredient = dbStockMovement.Ingredient.Name,
                        Quantity = dbStockMovement.Quantity,
                        Description = dbStockMovement.Description,
                        MovementType = dbStockMovement.MovementType,
                        CreatedAt = dbStockMovement.CreatedAt.ToLocalTime(),
                    };
                })
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var totalRecords = filteredMovements.Count();

            return new GetAllStockMovementQueryResponse
            {
                StockMovements = stockMovementDTOs,
                TotalRecords = totalRecords,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }


    }
}
