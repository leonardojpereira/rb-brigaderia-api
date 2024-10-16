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

            // Aplicar paginação
            var pagedStockMovements = dbStockMovements
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var stockMovementDTOs = pagedStockMovements
                .Select(dbStockMovement => new GetAllStockMovementDTO
                {
                    Id = dbStockMovement.Id,
                    IngredientId = dbStockMovement.IngredientId,
                    Quantity = dbStockMovement.Quantity,
                    Description = dbStockMovement.Description,
                    MovementType = dbStockMovement.MovementType,
                    CreatedAt = dbStockMovement.CreatedAt
                })
                .ToList();

            var totalRecords = dbStockMovements.Count();

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
