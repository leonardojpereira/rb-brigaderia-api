namespace Project.Application.Features.Queries.GetAllRoles
{
   public class GetAllRolesQueryResponse
    {
        public IEnumerable<GetAllRolesRoleDTO>? Roles { get; set; }
    }

    public class GetAllRolesRoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
