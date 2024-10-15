
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetIngredientById
{
    public class GetIngredientByIdQuery : Command<GetIngredientByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetIngredientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
