using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Features.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, GetAllRolesQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IRoleRepository _roleRepository;

        public GetAllRolesQueryHandler(IMediator mediator, IRoleRepository roleRepository)
        {
            _mediator = mediator;
            _roleRepository = roleRepository;
        }

        public async Task<GetAllRolesQueryResponse?> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync(cancellationToken);

            var roleDTOs = roles
                .Select(role => new GetAllRolesRoleDTO
                {
                    Id = role.Id,
                    Name = role.Name
                })
                .ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllRoles", "Roles retrieved successfully"), cancellationToken);

            return new GetAllRolesQueryResponse { Roles = roleDTOs };
        }
    }
}
