namespace Project.Application.Features.Commands.UpdateUser
{
    public record UpdateUserCommandRequest
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public Guid RoleId { get; set; }
    }
}
