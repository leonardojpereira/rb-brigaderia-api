namespace Project.Application.Features.Commands.CreateRecipe;

public record CreateRecipeCommandRequest
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public List<IngredienteQuantidadeDto> Ingredientes { get; set; } = new List<IngredienteQuantidadeDto>();

    public record IngredienteQuantidadeDto
    {
        public Guid IngredienteId { get; set; }
        public decimal QuantidadeNecessaria { get; set; }
    }
}
