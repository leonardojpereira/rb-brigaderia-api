using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateVendasCaixinhas;
using Project.Application.Features.Queries.GetAllIngredients;
using Project.Application.Features.Queries.GetAllVendasCaixinhas;
using Project.Application.Features.Queries.GetVendasCaixinhasById;
using Project.Application.Features.Commands.UpdateVendasCaixinhas;
using Project.Application.Features.Commands.DeleteVendasCaixinhas;
using Project.Application.Features.Queries.GetResumoVendasCaixinhas;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de vendas de caixinhas.
/// </summary>
[ApiController]
[SwaggerTag("Reúne endpoints para gerenciamento de vendas de caixinhas, incluindo criação, consulta, edição e exclusão.")]
[Route("api/v1/[controller]")]
public class VendasCaixinhasController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de vendas de caixinhas.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public VendasCaixinhasController(INotificationHandler<DomainNotification> notifications,
                                     INotificationHandler<DomainSuccessNotification> successNotifications,
                                     IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Cria uma nova venda de caixinhas.
    /// </summary>
    /// <param name="request">Objeto contendo os dados da venda a ser criada.</param>
    /// <returns>Status da operação de criação.</returns>
    /// <response code="200">Venda criada com sucesso.</response>
    /// <response code="400">Erro na validação dos dados enviados.</response>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [ProducesResponseType(typeof(CreateVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateVendasCaixinhas([FromBody] CreateVendasCaixinhasCommandRequest request)
    {
        return Response(await _mediatorHandler.Send(new CreateVendasCaixinhasCommand(request)));
    }

    /// <summary>
    /// Retorna todas as vendas de caixinhas com suporte a paginação e filtros opcionais.
    /// </summary>
    /// <param name="pageNumber">Número da página (padrão: 1).</param>
    /// <param name="pageSize">Quantidade de itens por página (padrão: 7).</param>
    /// <param name="date">Data específica para filtrar as vendas (opcional).</param>
    /// <param name="nomeVendedor">Nome do vendedor para filtro (opcional).</param>
    /// <returns>Uma lista paginada de vendas de caixinhas.</returns>
    /// <response code="200">Lista de vendas retornada com sucesso.</response>
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

    /// <summary>
    /// Retorna os detalhes de uma venda de caixinhas pelo ID.
    /// </summary>
    /// <param name="id">ID da venda a ser buscada.</param>
    /// <returns>Detalhes da venda solicitada.</returns>
    /// <response code="200">Detalhes da venda retornados com sucesso.</response>
    /// <response code="404">Venda não encontrada.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetVendasCaixinhasByIdQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetVendasCaixinhasById([FromRoute] Guid id)
    {
        return Response(await _mediatorHandler.Send(new GetVendasCaixinhasByIdQuery(id)));
    }

    /// <summary>
    /// Atualiza uma venda de caixinhas existente.
    /// </summary>
    /// <param name="id">ID da venda a ser atualizada.</param>
    /// <param name="request">Objeto contendo os novos dados da venda.</param>
    /// <returns>Status da operação de atualização.</returns>
    /// <response code="200">Venda atualizada com sucesso.</response>
    /// <response code="404">Venda não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateVendasCaixinhas([FromBody] UpdateVendasCaixinhasCommandRequest request, [FromRoute] Guid id)
    {
        var command = new UpdateVendasCaixinhasCommand(request, id);
        return Response(await _mediatorHandler.Send(command));
    }

    /// <summary>
    /// Remove uma venda de caixinhas pelo ID fornecido.
    /// </summary>
    /// <param name="id">ID da venda a ser removida.</param>
    /// <returns>Status da operação de exclusão.</returns>
    /// <response code="200">Venda removida com sucesso.</response>
    /// <response code="404">Venda não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(DeleteVendasCaixinhasCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteVendasCaixinhas([FromRoute] Guid id)
    {
        return Response(await _mediatorHandler.Send(new DeleteVendasCaixinhasCommand(id)));
    }

    /// <summary>
    /// Retorna o resumo das vendas de caixinhas com base nos filtros fornecidos.
    /// </summary>
    /// <param name="nomeVendedor">Nome do vendedor para filtro (opcional).</param>
    /// <param name="mes">Mês específico para filtro (opcional).</param>
    /// <param name="ano">Ano específico para filtro (opcional).</param>
    /// <returns>Resumo das vendas de caixinhas.</returns>
    /// <response code="200">Resumo das vendas retornado com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("Resume")]
    [ProducesResponseType(typeof(GetResumoVendasCaixinhasQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetResumoVendasCaixinhas(
        [FromQuery] string nomeVendedor = "",
        [FromQuery] int? mes = null,
        [FromQuery] int? ano = null)
    {
        var query = new GetResumoVendasCaixinhasQuery(nomeVendedor, mes, ano);
        return Response(await _mediatorHandler.Send(query));
    }
}
