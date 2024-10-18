namespace Project.Domain.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; set; }  
        public Guid IngredienteId { get; set; }  
        public decimal QuantidadeNecessaria { get; set; }

        public virtual Recipe? Recipe { get; set; }  
        public virtual Ingredient? Ingredient { get; set; }  
    }
}
