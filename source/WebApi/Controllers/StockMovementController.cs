using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.UpdateStockMovement;

namespace Project.WebApi.Controllers
{
    public class StockMovementController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(UpdateStockMovementCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateStockMovement([FromBody] UpdateStockMovementCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new UpdateStockMovementCommand(request)));
        }

        // Você pode descomentar essa parte se precisar da funcionalidade de obter todas as movimentações
        /*
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllStockMovementsQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStockMovements()
        {
            return Response(await _mediatorHandler.Send(new GetAllStockMovementsQuery()));
        }
        */
    }
}
