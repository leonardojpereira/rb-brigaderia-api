namespace Project.Application.Features.Commands.UpdateRecipe;

public record UpdateRecipeCommandResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<UpdateRecipeIngredientResponse> Ingredientes { get; set; } = new List<UpdateRecipeIngredientResponse>();

    public record UpdateRecipeIngredientResponse
    {
        public Guid IngredienteId { get; set; }
        public decimal QuantidadeNecessaria { get; set; }
        public string Nome { get; set; } = string.Empty; 
    }
}
