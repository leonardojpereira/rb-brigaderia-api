using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.RegisterUser;
using Project.Application.Features.Commands.LoginUser;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Queries.GetAllUsers;
using Project.Application.Features.Commands.DeleteUser;
using Project.Application.Features.Commands.UpdateUser;
using Project.Application.Features.Queries.GetUserById;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers
{
    /// <summary>
    /// Reúne endpoints para gerenciamento de usuários.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [SwaggerTag("Reúne endpoints para gerenciamento de usuários.")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediatorHandler;

        /// <summary>
        /// Construtor do controlador de usuários.
        /// </summary>
        /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
        /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
        /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
        public UserController(INotificationHandler<DomainNotification> notifications,
                              INotificationHandler<DomainSuccessNotification> successNotifications,
                              IMediator mediatorHandler)
            : base(notifications, successNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados com suporte a paginação e filtros opcionais.
        /// </summary>
        /// <param name="pageNumber">Número da página atual (padrão: 1).</param>
        /// <param name="pageSize">Quantidade de itens por página (padrão: 10).</param>
        /// <param name="filter">Filtro opcional para busca (ex: nome, e-mail).</param>
        /// <returns>Uma lista paginada de usuários.</returns>
        /// <response code="200">Retorna a lista de usuários com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetUsers")]
        [SwaggerOperation(Summary = "Lista todos os usuários", Description = "Retorna todos os usuários com suporte a paginação e filtros opcionais.")]
        [ProducesResponseType(typeof(GetAllUsersQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? filter = null)
        {
            var query = new GetAllUsersQuery(pageNumber, pageSize, filter);
            var result = await _mediatorHandler.Send(query);
            return Response(result);
        }

        /// <summary>
        /// Remove um usuário do sistema com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único do usuário a ser excluído.</param>
        /// <returns>Status da operação de exclusão.</returns>
        /// <response code="200">Usuário excluído com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteUser/{id}")]
        [SwaggerOperation(Summary = "Remove um usuário", Description = "Exclui um usuário com base no ID fornecido.")]
        [ProducesResponseType(typeof(DeleteUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            return Response(await _mediatorHandler.Send(new DeleteUserCommand(id)));
        }

        /// <summary>
        /// Atualiza os dados de um usuário específico.
        /// </summary>
        /// <param name="id">ID único do usuário a ser atualizado.</param>
        /// <param name="request">Objeto contendo os dados atualizados do usuário.</param>
        /// <returns>Status da operação de atualização.</returns>
        /// <response code="200">Usuário atualizado com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateUser/{id}")]
        [SwaggerOperation(Summary = "Atualiza um usuário", Description = "Atualiza os dados de um usuário específico com base no ID.")]
        [ProducesResponseType(typeof(UpdateUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateUserCommandRequest request)
        {
            var command = new UpdateUserCommand(request, id);
            var result = await _mediatorHandler.Send(command);
            return Response(result);
        }

        /// <summary>
        /// Busca os detalhes de um usuário com base no ID fornecido.
        /// </summary>
        /// <param name="id">ID único do usuário.</param>
        /// <returns>Detalhes do usuário solicitado.</returns>
        /// <response code="200">Retorna os dados do usuário com sucesso.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [Authorize(Roles = "Admin")]
        [HttpGet("GetUserById/{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário pelo ID", Description = "Retorna os detalhes de um usuário com base no ID fornecido.")]
        [ProducesResponseType(typeof(GetUserByIdQueryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediatorHandler.Send(query);
            return Response(result);
        }
    }
}
