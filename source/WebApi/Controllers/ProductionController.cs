using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateProduction;
using Project.Application.Features.Commands.DeleteProduction;
using Project.Application.Features.Commands.UpdateProduction;
using Project.Application.Features.Queries.GetAllProduction;
using Project.Application.Features.Queries.GetAllRecipe;
using Project.Application.Features.Queries.GetProductionById;
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
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllProductionQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductions([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7, [FromQuery] string? filter = null)
        {
            var query = new GetAllProductionQuery(pageNumber, pageSize, filter);
            var result = await _mediatorHandler.Send(query);
            return Response(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateProductionCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductionCommandRequest request)
        {
            var result = await _mediatorHandler.Send(new UpdateProductionCommand(request, id));
            return Response(result);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductionByIdQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediatorHandler.Send(new GetProductionByIdQuery(id));
            return Response(result);
        }
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteProductionCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _mediatorHandler.Send(new DeleteProductionCommand(id));
            return Response(result);
        }

    }
}
