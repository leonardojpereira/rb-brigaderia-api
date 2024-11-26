using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Commands.CreateIngredient;
using Project.Application.Features.Commands.DeleteIngredient;
using Project.Application.Features.Commands.UpdateIngredient;
using Project.Application.Features.Queries.GetIngredientById;
using Project.Application.Features.Queries.GetAllIngredients;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento de ingredientes.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [SwaggerTag("Reúne endpoints para gerenciamento de ingredientes, incluindo criação, consulta, edição e exclusão.")]
    public class IngredientController : BaseController
    {
        private readonly IMediator _mediatorHandler;

        /// <summary>
        /// Construtor do controlador de ingredientes.
        /// </summary>
        /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
        /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
        /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
        public IngredientController(INotificationHandler<DomainNotification> notifications,
                                    INotificationHandler<DomainSuccessNotification> successNotifications,
                                    IMediator mediatorHandler)
            : base(notifications, successNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Cria um novo ingrediente.
        /// </summary>
        /// <param name="request">Objeto contendo as informações do ingrediente a ser criado.</param>
        /// <returns>Status da operação de criação.</returns>
        /// <response code="200">Ingrediente criado com sucesso.</response>
        /// <response code="400">Erro na validação dos dados enviados.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo ingrediente", Description = "Adiciona um novo ingrediente ao sistema com base nas informações fornecidas.")]
        [ProducesResponseType(typeof(CreateIngredientCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new CreateIngredientCommand(request)));
        }

        /// <summary>
        /// Remove um ingrediente pelo ID fornecido.
        /// </summary>
        /// <param name="id">ID do ingrediente a ser removido.</param>
        /// <returns>Status da operação de exclusão.</returns>
        /// <response code="200">Ingrediente removido com sucesso.</response>
        /// <response code="404">Ingrediente não encontrado.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um ingrediente", Description = "Exclui um ingrediente do sistema com base no ID fornecido.")]
        [ProducesResponseType(typeof(DeleteIngredientCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIngredient([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new DeleteIngredientCommand(id)));
        }

        /// <summary>
        /// Atualiza as informações de um ingrediente.
        /// </summary>
        /// <param name="id">ID do ingrediente a ser atualizado.</param>
        /// <param name="request">Objeto contendo os novos dados do ingrediente.</param>
        /// <returns>Status da operação de atualização.</returns>
        /// <response code="200">Ingrediente atualizado com sucesso.</response>
        /// <response code="404">Ingrediente não encontrado.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um ingrediente", Description = "Atualiza as informações de um ingrediente com base no ID fornecido.")]
        [ProducesResponseType(typeof(UpdateIngredientCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredientCommandRequest request, [FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new UpdateIngredientCommand(request, id)));
        }

        /// <summary>
        /// Busca os detalhes de um ingrediente pelo ID fornecido.
        /// </summary>
        /// <param name="id">ID do ingrediente.</param>
        /// <returns>Detalhes do ingrediente solicitado.</returns>
        /// <response code="200">Detalhes do ingrediente retornados com sucesso.</response>
        /// <response code="404">Ingrediente não encontrado.</response>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um ingrediente pelo ID", Description = "Retorna os detalhes de um ingrediente com base no ID fornecido.")]
        [ProducesResponseType(typeof(GetIngredientByIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIngredientById([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new GetIngredientByIdQuery(id)));
        }

        /// <summary>
        /// Retorna todos os ingredientes cadastrados com suporte a paginação e filtros opcionais.
        /// </summary>
        /// <param name="filter">Filtro opcional para buscar ingredientes (exemplo: nome).</param>
        /// <param name="pageNumber">Número da página (padrão: 1).</param>
        /// <param name="pageSize">Quantidade de itens por página (padrão: 7).</param>
        /// <returns>Uma lista paginada de ingredientes.</returns>
        /// <response code="200">Lista de ingredientes retornada com sucesso.</response>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os ingredientes", Description = "Retorna uma lista paginada de ingredientes com suporte a filtros.")]
        [ProducesResponseType(typeof(GetAllIngredientsQueryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllIngredients([FromQuery] string? filter = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 7)
        {
            var query = new GetAllIngredientsQuery(pageNumber, pageSize, filter);
            return Response(await _mediatorHandler.Send(query));
        }
    }
}
