using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateProduction;
using Project.Application.Features.Commands.DeleteProduction;
using Project.Application.Features.Commands.UpdateProduction;
using Project.Application.Features.Queries.GetAllProduction;
using Project.Application.Features.Queries.GetProductionById;
using Project.Domain.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de produções.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Reúne endpoints para gerenciamento de produções, incluindo criação, consulta, edição e exclusão.")]
public class ProductionController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de produções.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public ProductionController(INotificationHandler<DomainNotification> notifications,
                                INotificationHandler<DomainSuccessNotification> successNotifications,
                                IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Cria uma nova produção.
    /// </summary>
    /// <param name="request">Objeto contendo os dados da produção a ser criada.</param>
    /// <returns>Status da operação de criação.</returns>
    /// <response code="200">Produção criada com sucesso.</response>
    /// <response code="400">Erro na validação dos dados enviados.</response>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Cria uma nova produção", Description = "Adiciona uma nova produção ao sistema com base nos dados fornecidos.")]
    [ProducesResponseType(typeof(CreateProductionCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProductionCommandRequest request)
    {
        var result = await _mediatorHandler.Send(new CreateProductionCommand(request));
        return Response(result);
    }

    /// <summary>
    /// Retorna todas as produções cadastradas com suporte a paginação e filtros opcionais.
    /// </summary>
    /// <param name="pageNumber">Número da página (padrão: 1).</param>
    /// <param name="pageSize">Quantidade de itens por página (padrão: 7).</param>
    /// <param name="filter">Filtro opcional para busca de produções (ex.: nome).</param>
    /// <returns>Uma lista paginada de produções.</returns>
    /// <response code="200">Lista de produções retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    [SwaggerOperation(Summary = "Lista todas as produções", Description = "Retorna uma lista paginada de produções com suporte a filtros opcionais.")]
    [ProducesResponseType(typeof(GetAllProductionQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllProductions([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7, [FromQuery] string? filter = null)
    {
        var query = new GetAllProductionQuery(pageNumber, pageSize, filter);
        var result = await _mediatorHandler.Send(query);
        return Response(result);
    }

    /// <summary>
    /// Atualiza uma produção existente.
    /// </summary>
    /// <param name="id">ID da produção a ser atualizada.</param>
    /// <param name="request">Objeto contendo os novos dados da produção.</param>
    /// <returns>Status da operação de atualização.</returns>
    /// <response code="200">Produção atualizada com sucesso.</response>
    /// <response code="404">Produção não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza uma produção", Description = "Atualiza os dados de uma produção com base no ID fornecido.")]
    [ProducesResponseType(typeof(UpdateProductionCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductionCommandRequest request)
    {
        var result = await _mediatorHandler.Send(new UpdateProductionCommand(request, id));
        return Response(result);
    }

    /// <summary>
    /// Retorna os detalhes de uma produção específica pelo ID.
    /// </summary>
    /// <param name="id">ID da produção a ser buscada.</param>
    /// <returns>Detalhes da produção solicitada.</returns>
    /// <response code="200">Detalhes da produção retornados com sucesso.</response>
    /// <response code="404">Produção não encontrada.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém uma produção pelo ID", Description = "Retorna os detalhes de uma produção com base no ID fornecido.")]
    [ProducesResponseType(typeof(GetProductionByIdQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await _mediatorHandler.Send(new GetProductionByIdQuery(id));
        return Response(result);
    }

    /// <summary>
    /// Remove uma produção pelo ID fornecido.
    /// </summary>
    /// <param name="id">ID da produção a ser removida.</param>
    /// <returns>Status da operação de exclusão.</returns>
    /// <response code="200">Produção removida com sucesso.</response>
    /// <response code="404">Produção não encontrada.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remove uma produção", Description = "Exclui uma produção com base no ID fornecido.")]
    [ProducesResponseType(typeof(DeleteProductionCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _mediatorHandler.Send(new DeleteProductionCommand(id));
        return Response(result);
    }
}
