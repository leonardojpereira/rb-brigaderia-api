namespace Project.Application.Features.Queries.GetRecipeById
{
    public class GetRecipeByIdQueryResponse
    {
        public GetRecipeByIdRecipeDTO? Recipe { get; set; }
    }

    public class GetRecipeByIdRecipeDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public List<GetRecipeByIdIngredientDTO> Ingredients { get; set; } = new();
    }

    public class GetRecipeByIdIngredientDTO
    {
        public Guid IngredienteId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal QuantidadeNecessaria { get; set; }
    }
}
