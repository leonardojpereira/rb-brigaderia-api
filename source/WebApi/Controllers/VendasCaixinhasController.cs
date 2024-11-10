using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateVendasCaixinhas;
using Project.Application.Features.Queries.GetAllIngredients;
using Project.Application.Features.Queries.GetAllVendasCaixinhas;

namespace Project.WebApi.Controllers
{
    public class VendasCaixinhasController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVendasCaixinhas([FromBody] CreateVendasCaixinhasCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new CreateVendasCaixinhasCommand(request)));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllVendasCaixinhasQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllVendasCaixinhas([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7)
        {
            var query = new GetAllVendasCaixinhasQuery(pageNumber, pageSize);
            return Response(await _mediatorHandler.Send(query));
        }
    }
}
