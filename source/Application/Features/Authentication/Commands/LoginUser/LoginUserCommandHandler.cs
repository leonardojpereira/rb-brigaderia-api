using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Interfaces.Services;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IMediator mediator) : IRequestHandler<LoginUserCommand, LoginUserCommandResponse?>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IMediator _mediator = mediator;

    public async Task<LoginUserCommandResponse?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        request.Request.Login = request.Request.Login.ToLowerInvariant();

        var user = await _userRepository.GetByUsernameOrEmailAsync(request.Request.Login, cancellationToken);

        if (user == null || !user.VerifyPassword(request.Request.Password))
        {
            await _mediator.Publish(new DomainNotification("LoginUser", "Usuário não encontrado. Por favor, tente novamente."), cancellationToken);
            return default;
        }

        var token = _tokenService.GenerateToken(user);
        return new LoginUserCommandResponse
        {
            Token = token,
            Username = user.Username,
            Nome = user.Nome,
            Email = user.Email,
            Role = user.Role?.Name ?? string.Empty,
            Id = user.Id
        };
    }

}
