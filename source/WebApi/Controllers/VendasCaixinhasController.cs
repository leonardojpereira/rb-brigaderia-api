using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateVendasCaixinhas;
using Project.Application.Features.Queries.GetAllIngredients;
using Project.Application.Features.Queries.GetAllVendasCaixinhas;
using Project.Application.Features.Queries.GetVendasCaixinhasById;
using Project.Application.Features.Commands.UpdateVendasCaixinhas;
using Project.Application.Features.Commands.DeleteVendasCaixinhas;

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

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllVendasCaixinhasQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllVendasCaixinhas(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 7,
        [FromQuery] DateTime? date = null,
        [FromQuery] string nomeVendedor = "")
        
        {
            var query = new GetAllVendasCaixinhasQuery(pageNumber, pageSize, date, nomeVendedor);
            return Response(await _mediatorHandler.Send(query));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetVendasCaixinhasByIdQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVendasCaixinhasById([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new GetVendasCaixinhasByIdQuery(id)));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateVendasCaixinhas([FromBody] UpdateVendasCaixinhasCommandRequest request, [FromRoute] Guid id)
        {
            var command = new UpdateVendasCaixinhasCommand(request, id);
            return Response(await _mediatorHandler.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteVendasCaixinhas([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new DeleteVendasCaixinhasCommand(id)));
        }

    }
}
