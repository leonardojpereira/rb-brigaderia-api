
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllIngredients
{
    public class GetAllIngredientsQuery : Command<GetAllIngredientsQueryResponse>
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 7;
        public string? Filter { get; set; }


        public GetAllIngredientsQuery(int pageNumber = 1, int pageSize = 10, string? filter = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Filter = filter;
        }
    }
}
