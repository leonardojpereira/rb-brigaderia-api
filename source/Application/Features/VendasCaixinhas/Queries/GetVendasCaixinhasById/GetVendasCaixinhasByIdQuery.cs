using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetVendasCaixinhasById
{
    public class GetVendasCaixinhasByIdQuery : Command<GetVendasCaixinhasByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetVendasCaixinhasByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
