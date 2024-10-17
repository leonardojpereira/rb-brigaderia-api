using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateRecipe;
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
    }
}
