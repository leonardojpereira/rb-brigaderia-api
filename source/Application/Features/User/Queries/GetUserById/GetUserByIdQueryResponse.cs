namespace Project.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQueryResponse
    {
        public GetUserByIdDTO? User { get; set; }
    }

    public class GetUserByIdDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid roleId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
