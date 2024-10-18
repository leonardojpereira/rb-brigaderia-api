using Project.Domain.Entities;

namespace Project.Application.Features.Commands.UpdateRecipe;

public record UpdateRecipeCommandRequest
{
    public string Nome { get; set; } = string.Empty; 
    public string Descricao { get; set; } = string.Empty; 
    public List<RecipeIngredientRequest> Ingredientes { get; set; } = new List<RecipeIngredientRequest>();

    public record RecipeIngredientRequest
    {
        public Guid IngredienteId { get; set; } 
        public decimal QuantidadeNecessaria { get; set; } 
    }
}
