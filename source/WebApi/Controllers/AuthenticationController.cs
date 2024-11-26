using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.RegisterUser;
using Project.Application.Features.Commands.LoginUser;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers
{
    /// <summary>
    /// Controlador responsável por autenticação de usuários, incluindo registro e login.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [SwaggerTag("Reúne endpoints para autenticação de usuários, como registro e login.")]
    public class AuthenticationController : BaseController
    {
        private readonly IMediator _mediatorHandler;

        /// <summary>
        /// Construtor do controlador de autenticação.
        /// </summary>
        /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
        /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
        /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
        public AuthenticationController(INotificationHandler<DomainNotification> notifications,
                                        INotificationHandler<DomainSuccessNotification> successNotifications,
                                        IMediator mediatorHandler)
            : base(notifications, successNotifications, mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Realiza o registro de um novo usuário no sistema.
        /// </summary>
        /// <param name="request">Objeto contendo as informações do usuário a ser registrado.</param>
        /// <returns>Status da operação de registro.</returns>
        /// <response code="200">Usuário registrado com sucesso.</response>
        /// <response code="400">Erro na validação dos dados enviados.</response>
        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        [SwaggerOperation(Summary = "Registra um novo usuário", Description = "Cria um novo usuário no sistema com base nas informações fornecidas.")]
        [ProducesResponseType(typeof(RegisterUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new RegisterUserCommand(request)));
        }

        /// <summary>
        /// Realiza o login de um usuário no sistema.
        /// </summary>
        /// <param name="request">Objeto contendo as credenciais do usuário.</param>
        /// <returns>Token de autenticação e informações básicas do usuário.</returns>
        /// <response code="200">Login realizado com sucesso.</response>
        /// <response code="401">Credenciais inválidas.</response>
        [HttpPost("Login")]
        [SwaggerOperation(Summary = "Realiza o login de um usuário", Description = "Autentica um usuário com base nas credenciais fornecidas e retorna um token de acesso.")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new LoginUserCommand(request)));
        }
    }
}
