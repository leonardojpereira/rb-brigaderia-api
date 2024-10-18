using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateRecipe;
using Project.Application.Features.Commands.UpdateRecipe;
using Project.Application.Features.Queries.GetAllRecipe;
using Project.Application.Features.Queries.GetRecipeById;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers
{
    public class RecipeController(INotificationHandler<DomainNotification> notifications,
                                  INotificationHandler<DomainSuccessNotification> successNotifications,
                                  IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(CreateRecipeCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateRecipeCommandRequest request)
        {
            var result = await _mediatorHandler.Send(new CreateRecipeCommand(request));
            return Response(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateRecipeCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateRecipeCommandRequest request, [FromRoute] Guid id)
        {
            var result = await _mediatorHandler.Send(new UpdateRecipeCommand(request, id));
            return Response(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(typeof(GetAllRecipeQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRecipes()
        {
            var result = await _mediatorHandler.Send(new GetAllRecipeQuery());
            return Response(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetRecipeByIdQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRecipeById([FromRoute] Guid id)
        {
            var result = await _mediatorHandler.Send(new GetRecipeByIdQuery(id));
            return Response(result);

        }
    }
}
