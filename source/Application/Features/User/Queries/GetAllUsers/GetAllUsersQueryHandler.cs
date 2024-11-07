using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;
using MediatR;

namespace Project.Application.Features.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersQueryResponse?>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersQueryResponse?> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var filteredUsers = string.IsNullOrEmpty(request.Filter)
                ? await _userRepository.GetAllAsync(cancellationToken)
                : await _userRepository.GetByFilterAsync(request.Filter, cancellationToken);

            var totalUsers = filteredUsers.Count();

            // Paginação
            var dbUsers = filteredUsers
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var userDTOs = dbUsers
                .Select(dbUser => new GetAllUsersUserDTO
                {
                    Id = dbUser.Id,
                    Nome = dbUser.Nome,
                    Email = dbUser.Email,
                    Role = dbUser.Role?.Name ?? "No Role Assigned"
                })
                .ToList();

            await _mediator.Publish(new DomainSuccessNotification("GetAllUsers", "Users retrieved successfully"), cancellationToken);

            return new GetAllUsersQueryResponse 
            { 
                Users = userDTOs,
                TotalItems = totalUsers,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
