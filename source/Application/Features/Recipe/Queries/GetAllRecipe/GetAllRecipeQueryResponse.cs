namespace Project.Application.Features.Queries.GetAllRecipe
{
    public class GetAllRecipeQueryResponse
    {
        public IEnumerable<GetAllRecipeDTO> Recipes { get; set; } = new List<GetAllRecipeDTO>();
    }

    public class GetAllRecipeDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal CustoTotal { get; set; } 

        public List<GetAllRecipeIngredientDTO> Ingredientes { get; set; } = new List<GetAllRecipeIngredientDTO>();

    }

    public class GetAllRecipeIngredientDTO
    {
        public Guid IngredienteId { get; set; }
        public decimal QuantidadeNecessaria { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
