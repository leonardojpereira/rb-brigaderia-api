using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.UpdateStockMovement;
using Project.Application.Features.Queries.GetAllStockMovement;
using MediatR;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementController : BaseController
    {
        private readonly IMediator _mediatorHandler;

        public StockMovementController(INotificationHandler<DomainNotification> notifications,
                                       INotificationHandler<DomainSuccessNotification> successNotifications,
                                       IMediator mediatorHandler) : base(notifications, successNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        // Endpoint para atualizar movimentação de estoque
        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(UpdateStockMovementCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateStockMovement([FromBody] UpdateStockMovementCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new UpdateStockMovementCommand(request)));
        }

        // Endpoint para obter todas as movimentações de estoque
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllStockMovementQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStockMovements([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetAllStockMovementQuery(pageNumber, pageSize);
            return Response(await _mediatorHandler.Send(query));
        }

    }
}
