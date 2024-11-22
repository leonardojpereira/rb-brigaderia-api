using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetParametrizacaoById;

public class GetParametrizacaoByIdQuery : Command<GetParametrizacaoByIdQueryResponse>
{
    public Guid Id { get; set; }

    public GetParametrizacaoByIdQuery(Guid id)
    {
        Id = id;
    }
}
