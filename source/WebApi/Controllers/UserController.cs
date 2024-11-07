using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.RegisterUser;
using Project.Application.Features.Commands.LoginUser;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Queries.GetAllUsers;
using Project.Application.Features.Commands.DeleteUser;

namespace Project.WebApi.Controllers
{
    public class UserController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(typeof(GetAllUsersQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? filter = null)
        {
            var query = new GetAllUsersQuery(pageNumber, pageSize, filter);
            var result = await _mediatorHandler.Send(query);
            return Response(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser/{id}")]
        [ProducesResponseType(typeof(DeleteUserCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new DeleteUserCommand(id)));
        }
    }
}
