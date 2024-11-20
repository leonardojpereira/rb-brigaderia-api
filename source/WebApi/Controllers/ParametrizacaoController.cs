using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateParametrizacao;
using Project.Application.Features.Queries.GetAllParametrizacao;
using Project.Application.Features.Queries.GetParametrizacaoById;
using Project.Application.Features.Commands.UpdateParametrizacao;
// using Project.Application.Features.Commands.DeleteParametrizacao;

namespace Project.WebApi.Controllers;

public class ParametrizacaoController(INotificationHandler<DomainNotification> notifications,
                        INotificationHandler<DomainSuccessNotification> successNotifications,
                        IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler)
{
    private readonly IMediator _mediatorHandler = mediatorHandler;

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(typeof(CreateParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateParametrizacao([FromBody] CreateParametrizacaoCommandRequest request)
    {
        return Response(await _mediatorHandler.Send(new CreateParametrizacaoCommand(request)));
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    [ProducesResponseType(typeof(GetAllParametrizacaoQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllParametrizacao(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 7,
        [FromQuery] string? nomeVendedor = null)
    {
        var query = new GetAllParametrizacaoQuery(pageNumber, pageSize, nomeVendedor);
        return Response(await _mediatorHandler.Send(query));
    }

    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetParametrizacaoByIdQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetParametrizacaoById([FromRoute] Guid id)
    {
        return Response(await _mediatorHandler.Send(new GetParametrizacaoByIdQuery(id)));
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateParametrizacao([FromBody] UpdateParametrizacaoCommandRequest request, [FromRoute] Guid id)
    {
        var command = new UpdateParametrizacaoCommand(request, id);
        return Response(await _mediatorHandler.Send(command));
    }

    // [Authorize(Roles = "Admin")]
    // [HttpDelete("{id}")]
    // [ProducesResponseType(typeof(DeleteParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    // public async Task<IActionResult> DeleteParametrizacao([FromRoute] Guid id)
    // {
    //     return Response(await _mediatorHandler.Send(new DeleteParametrizacaoCommand(id)));
    // }
}
