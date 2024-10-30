
using Project.Domain.Notifications;

namespace Project.Application.Features.Queries.GetAllRecipe
{
    public class GetAllRecipeQuery : Command<GetAllRecipeQueryResponse>
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 7;
        public string? Filter { get; set; }
        public GetAllRecipeQuery(int pageNumber = 1, int pageSize = 10, string? filter = null)
        {

            PageNumber = pageNumber;
            PageSize = pageSize;
            Filter = filter;
        }
    }
}
