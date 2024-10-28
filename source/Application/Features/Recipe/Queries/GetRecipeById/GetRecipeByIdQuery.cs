
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetRecipeById
{
    public class GetRecipeByIdQuery : Command<GetRecipeByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetRecipeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
