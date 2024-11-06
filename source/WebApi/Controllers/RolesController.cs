using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Queries.GetAllRoles;
using Project.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Project.WebApi.Controllers
{
    [Authorize(Roles = "Admin, User"),]
    public class RolesController(INotificationHandler<DomainNotification> notifications,
                                    INotificationHandler<DomainSuccessNotification> successNotifications,
                                    IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [HttpGet("GetAllRoles")]
        [ProducesResponseType(typeof(GetAllRolesQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _mediatorHandler.Send(new GetAllRolesQuery());
            return Response(result);
        }
    }
}
