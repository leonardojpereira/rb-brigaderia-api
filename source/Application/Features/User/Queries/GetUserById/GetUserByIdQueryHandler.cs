
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _UserRepository;

        public GetUserByIdQueryHandler(IMediator mediator, IUserRepository UserRepository)
        {
            _mediator = mediator;
            _UserRepository = UserRepository;
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var dbUser = await _UserRepository.GetByIdAsync(request.Id, cancellationToken);
            if (dbUser is null)
            {
                await _mediator.Publish(new DomainNotification("GetUserById", "User not found"), cancellationToken);
                return default;
            }

            await _mediator.Publish(new DomainSuccessNotification("GetUserById", "User found successfully"), cancellationToken);

            var userDTO = new GetUserByIdDTO
            {
                Id = dbUser.Id,
                Nome = dbUser.Nome,
                Email = dbUser.Email,
                roleId = dbUser.RoleId,
                Role = dbUser.Role?.Name ?? string.Empty
            };

            return new GetUserByIdQueryResponse { User = userDTO };
        }

    }
}