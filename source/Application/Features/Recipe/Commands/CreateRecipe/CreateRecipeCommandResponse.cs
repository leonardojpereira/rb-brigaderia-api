namespace Project.Application.Features.Commands.CreateRecipe;

public record CreateRecipeCommandResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<CreateIngredienteQuantidadeResponse> Ingredientes { get; set; } = new List<CreateIngredienteQuantidadeResponse>();

    public record CreateIngredienteQuantidadeResponse
    {
        public Guid IngredienteId { get; set; }
        public decimal QuantidadeNecessaria { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
