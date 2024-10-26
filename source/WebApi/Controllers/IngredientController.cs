using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateIngredient;
using Project.Application.Features.Commands.DeleteIngredient;
using Project.Application.Features.Commands.UpdateIngredient;
using Project.Application.Features.Queries.GetIngredientById;
using Project.Application.Features.Queries.GetAllIngredients;

namespace Project.WebApi.Controllers
{
    public class IngredientController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateIngredientCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new CreateIngredientCommand(request)));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DeleteIngredientCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteIngredient([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new DeleteIngredientCommand(id)));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateIngredientCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredientCommandRequest request, [FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new UpdateIngredientCommand(request, id)));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetIngredientByIdQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetIngredientById([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new GetIngredientByIdQuery(id)));
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllIngredientsQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllIngredients([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7)
        {
            var query = new GetAllIngredientsQuery(pageNumber, pageSize);
            return Response(await _mediatorHandler.Send(query));
        }

    }
}
