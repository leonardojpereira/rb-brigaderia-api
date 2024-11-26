using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.UpdateStockMovement;
using Project.Application.Features.Queries.GetAllStockMovement;
using MediatR;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de movimentações de estoque.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class StockMovementController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de movimentações de estoque.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public StockMovementController(INotificationHandler<DomainNotification> notifications,
                                   INotificationHandler<DomainSuccessNotification> successNotifications,
                                   IMediator mediatorHandler) 
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Atualiza uma movimentação de estoque.
    /// </summary>
    /// <param name="request">Objeto contendo os dados da movimentação de estoque a ser atualizada.</param>
    /// <returns>Status da operação de atualização.</returns>
    /// <response code="200">Movimentação de estoque atualizada com sucesso.</response>
    /// <response code="400">Erro na validação dos dados enviados.</response>
    [Authorize(Roles = "Admin")]
    [HttpPut]
    [ProducesResponseType(typeof(UpdateStockMovementCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateStockMovement([FromBody] UpdateStockMovementCommandRequest request)
    {
        return Response(await _mediatorHandler.Send(new UpdateStockMovementCommand(request)));
    }

    /// <summary>
    /// Retorna todas as movimentações de estoque com suporte a paginação e filtros opcionais.
    /// </summary>
    /// <param name="pageNumber">Número da página (padrão: 1).</param>
    /// <param name="pageSize">Quantidade de itens por página (padrão: 10).</param>
    /// <param name="dataInicial">Data inicial para o filtro de movimentações (opcional).</param>
    /// <param name="dataFinal">Data final para o filtro de movimentações (opcional).</param>
    /// <returns>Uma lista paginada de movimentações de estoque.</returns>
    /// <response code="200">Lista de movimentações de estoque retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    [ProducesResponseType(typeof(GetAllStockMovementQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllStockMovements(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] DateTime? dataInicial = null,
        [FromQuery] DateTime? dataFinal = null)
    {
        var query = new GetAllStockMovementQuery(pageNumber, pageSize, dataInicial, dataFinal);
        return Response(await _mediatorHandler.Send(query));
    }
}
