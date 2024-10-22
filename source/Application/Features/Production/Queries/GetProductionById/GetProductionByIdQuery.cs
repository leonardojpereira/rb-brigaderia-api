using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetProductionById
{
    public class GetProductionByIdQuery : Command<GetProductionByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetProductionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
