using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateProduction;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers
{
    public class ProductionController(INotificationHandler<DomainNotification> notifications,
                                      INotificationHandler<DomainSuccessNotification> successNotifications,
                                      IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateProductionCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateProductionCommandRequest request)
        {
            var result = await _mediatorHandler.Send(new CreateProductionCommand(request));
            return Response(result);
        }

    }
}
