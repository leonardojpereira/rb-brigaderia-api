using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.CreateRecipe;
using Project.Application.Features.Commands.DeleteRecipe;
using Project.Application.Features.Commands.UpdateRecipe;
using Project.Application.Features.Queries.GetAllRecipe;
using Project.Application.Features.Queries.GetRecipeById;
using Project.Domain.Notifications;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável pelo gerenciamento de receitas.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[SwaggerTag("Reúne endpoints para gerenciamento de receitas, incluindo criação, consulta, edição e exclusão.")]
public class RecipeController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de receitas.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public RecipeController(INotificationHandler<DomainNotification> notifications,
                            INotificationHandler<DomainSuccessNotification> successNotifications,
                            IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Cria uma nova receita.
    /// </summary>
    /// <param name="request">Objeto contendo os dados da receita a ser criada.</param>
    /// <returns>Status da operação de criação.</returns>
    /// <response code="200">Receita criada com sucesso.</response>
    /// <response code="400">Erro na validação dos dados enviados.</response>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    [SwaggerOperation(Summary = "Cria uma nova receita", Description = "Adiciona uma nova receita ao sistema com base nos dados fornecidos.")]
    [ProducesResponseType(typeof(CreateRecipeCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateRecipeCommandRequest request)
    {
        var result = await _mediatorHandler.Send(new CreateRecipeCommand(request));
        return Response(result);
    }

    /// <summary>
    /// Atualiza uma receita existente.
    /// </summary>
    /// <param name="id">ID da receita a ser atualizada.</param>
    /// <param name="request">Objeto contendo os novos dados da receita.</param>
    /// <returns>Status da operação de atualização.</returns>
    /// <response code="200">Receita atualizada com sucesso.</response>
    /// <response code="404">Receita não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Atualiza uma receita", Description = "Atualiza os dados de uma receita com base no ID fornecido.")]
    [ProducesResponseType(typeof(UpdateRecipeCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] UpdateRecipeCommandRequest request, [FromRoute] Guid id)
    {
        var result = await _mediatorHandler.Send(new UpdateRecipeCommand(request, id));
        return Response(result);
    }

    /// <summary>
    /// Retorna todas as receitas cadastradas com suporte a paginação e filtros opcionais.
    /// </summary>
    /// <param name="pageNumber">Número da página (padrão: 1).</param>
    /// <param name="pageSize">Quantidade de itens por página (padrão: 7).</param>
    /// <param name="filter">Filtro opcional para buscar receitas (ex.: nome).</param>
    /// <returns>Uma lista paginada de receitas.</returns>
    /// <response code="200">Lista de receitas retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet]
    [SwaggerOperation(Summary = "Lista todas as receitas", Description = "Retorna uma lista paginada de receitas com suporte a filtros opcionais.")]
    [ProducesResponseType(typeof(GetAllRecipeQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllRecipes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7, [FromQuery] string? filter = null)
    {
        var query = new GetAllRecipeQuery(pageNumber, pageSize, filter);
        var result = await _mediatorHandler.Send(query);
        return Response(result);
    }

    /// <summary>
    /// Retorna os detalhes de uma receita específica pelo ID.
    /// </summary>
    /// <param name="id">ID da receita a ser buscada.</param>
    /// <returns>Detalhes da receita solicitada.</returns>
    /// <response code="200">Detalhes da receita retornados com sucesso.</response>
    /// <response code="404">Receita não encontrada.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtém uma receita pelo ID", Description = "Retorna os detalhes de uma receita com base no ID fornecido.")]
    [ProducesResponseType(typeof(GetRecipeByIdQueryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetRecipeById([FromRoute] Guid id)
    {
        var result = await _mediatorHandler.Send(new GetRecipeByIdQuery(id));
        return Response(result);
    }

    /// <summary>
    /// Remove uma receita pelo ID fornecido.
    /// </summary>
    /// <param name="id">ID da receita a ser removida.</param>
    /// <returns>Status da operação de exclusão.</returns>
    /// <response code="200">Receita removida com sucesso.</response>
    /// <response code="404">Receita não encontrada.</response>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Remove uma receita", Description = "Exclui uma receita com base no ID fornecido.")]
    [ProducesResponseType(typeof(DeleteRecipeCommandResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _mediatorHandler.Send(new DeleteRecipeCommand(id));
        return Response(result);
    }

    /// <summary>
    /// Retorna as receitas mais produzidas.
    /// </summary>
    /// <returns>Uma lista com as receitas mais produzidas.</returns>
    /// <response code="200">Lista de receitas retornada com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("TopProduced")]
    [SwaggerOperation(Summary = "Lista as receitas mais produzidas", Description = "Retorna uma lista das receitas que foram mais produzidas.")]
    [ProducesResponseType(typeof(GetTopProducedRecipesQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTopProducedRecipes()
    {
        var result = await _mediatorHandler.Send(new GetTopProducedRecipesQuery());
        return Response(result);
    }
}
