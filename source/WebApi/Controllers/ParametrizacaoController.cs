using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateParametrizacao;
using Project.Application.Features.Queries.GetAllParametrizacao;
using Project.Application.Features.Queries.GetParametrizacaoById;
using Project.Application.Features.Commands.UpdateParametrizacao;
using Project.Application.Features.Commands.DeleteParametrizacao;
using Project.Application.Features.Queries.GetVendedoresParametrizacao;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de parametrizações.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Reúne endpoints para gerenciamento de parametrizações, incluindo criação, edição, consulta e exclusão.")]
public class ParametrizacaoController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de parametrizações.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public ParametrizacaoController(INotificationHandler<DomainNotification> notifications,
                                    INotificationHandler<DomainSuccessNotification> successNotifications,
                                    IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Cria uma nova parametrização.
    /// </summary>
    /// <param name="request">Objeto contendo os dados da parametrização a ser criada.</param>
    /// <returns>Status da operação de criação.</returns>
    /// <response code="200">Parametrização criada com sucesso.</response>
    /// <response code="400">Erro na validação dos dados enviados.</response>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Cria uma nova parametrização", Description = "Adiciona uma nova parametrização ao sistema com base nas informações fornecidas.")]
    [ProducesResponseType(typeof(CreateParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateParametrizacao([FromBody] CreateParametrizacaoCommandRequest request)
    {
        return Response(await _mediatorHandler.Send(new CreateParametrizacaoCommand(request)));
    }

    /// <summary>
    /// Retorna todas as parametrizações cadastradas com suporte a paginação e filtros opcionais.
    /// </summary>
    /// <param name="pageNumber">Número da página (padrão: 1).</param>
    /// <param name="pageSize">Quantidade de itens por página (padrão: 7).</param>
    /// <param name="nomeVendedor">Filtro opcional pelo nome do vendedor.</param>
    /// <returns>Uma lista paginada de parametrizações.</returns>
    /// <response code="200">Lista de parametrizações retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    [SwaggerOperation(Summary = "Lista todas as parametrizações", Description = "Retorna uma lista paginada de parametrizações com suporte a filtros opcionais.")]
    [ProducesResponseType(typeof(GetAllParametrizacaoQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllParametrizacao(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 7,
        [FromQuery] string? nomeVendedor = null)
    {
        var query = new GetAllParametrizacaoQuery(pageNumber, pageSize, nomeVendedor);
        return Response(await _mediatorHandler.Send(query));
    }

    /// <summary>
    /// Retorna os detalhes de uma parametrização específica pelo ID.
    /// </summary>
    /// <param name="id">ID da parametrização a ser buscada.</param>
    /// <returns>Detalhes da parametrização solicitada.</returns>
    /// <response code="200">Detalhes da parametrização retornados com sucesso.</response>
    /// <response code="404">Parametrização não encontrada.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém uma parametrização pelo ID", Description = "Retorna os detalhes de uma parametrização com base no ID fornecido.")]
    [ProducesResponseType(typeof(GetParametrizacaoByIdQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetParametrizacaoById([FromRoute] Guid id)
    {
        return Response(await _mediatorHandler.Send(new GetParametrizacaoByIdQuery(id)));
    }

    /// <summary>
    /// Atualiza as informações de uma parametrização.
    /// </summary>
    /// <param name="id">ID da parametrização a ser atualizada.</param>
    /// <param name="request">Objeto contendo os novos dados da parametrização.</param>
    /// <returns>Status da operação de atualização.</returns>
    /// <response code="200">Parametrização atualizada com sucesso.</response>
    /// <response code="404">Parametrização não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza uma parametrização", Description = "Atualiza as informações de uma parametrização com base no ID fornecido.")]
    [ProducesResponseType(typeof(UpdateParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateParametrizacao([FromBody] UpdateParametrizacaoCommandRequest request, [FromRoute] Guid id)
    {
        var command = new UpdateParametrizacaoCommand(request, id);
        return Response(await _mediatorHandler.Send(command));
    }

    /// <summary>
    /// Remove uma parametrização pelo ID fornecido.
    /// </summary>
    /// <param name="id">ID da parametrização a ser removida.</param>
    /// <returns>Status da operação de exclusão.</returns>
    /// <response code="200">Parametrização removida com sucesso.</response>
    /// <response code="404">Parametrização não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remove uma parametrização", Description = "Exclui uma parametrização com base no ID fornecido.")]
    [ProducesResponseType(typeof(DeleteParametrizacaoCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteParametrizacao([FromRoute] Guid id)
    {
        return Response(await _mediatorHandler.Send(new DeleteParametrizacaoCommand(id)));
    }

    /// <summary>
    /// Retorna a lista de vendedores associados às parametrizações.
    /// </summary>
    /// <returns>Lista de vendedores parametrizados.</returns>
    /// <response code="200">Lista de vendedores retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("Vendedores")]
    [SwaggerOperation(Summary = "Lista os vendedores parametrizados", Description = "Retorna a lista de vendedores associados às parametrizações.")]
    [ProducesResponseType(typeof(GetVendedoresParametrizacaoQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetVendedoresParametrizacao()
    {
        return Response(await _mediatorHandler.Send(new GetVendedoresParametrizacaoQuery()));
    }
}
