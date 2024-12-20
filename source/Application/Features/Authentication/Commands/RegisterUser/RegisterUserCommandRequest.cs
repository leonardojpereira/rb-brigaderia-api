namespace Project.Application.Features.Commands.RegisterUser;

public record RegisterUserCommandRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Guid RoleId { get; set; } 
}