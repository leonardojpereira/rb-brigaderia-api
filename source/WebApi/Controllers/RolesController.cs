using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Queries.GetAllRoles;
using Project.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de roles (perfis de usuário).
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Reúne endpoints para gerenciamento de roles (perfis de usuário), incluindo consulta.")]

[Authorize(Roles = "Admin, User")]
public class RolesController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de roles.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public RolesController(INotificationHandler<DomainNotification> notifications,
                           INotificationHandler<DomainSuccessNotification> successNotifications,
                           IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Retorna a lista de todos os roles (perfis de usuário) cadastrados.
    /// </summary>
    /// <returns>Uma lista de roles.</returns>
    /// <response code="200">Lista de roles retornada com sucesso.</response>
    [HttpGet("GetAllRoles")]
    [ProducesResponseType(typeof(GetAllRolesQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRoles()
    {
        var result = await _mediatorHandler.Send(new GetAllRolesQuery());
        return Response(result);
    }
}
