
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetUserById
{
    public class GetUserByIdQuery : Command<GetUserByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
