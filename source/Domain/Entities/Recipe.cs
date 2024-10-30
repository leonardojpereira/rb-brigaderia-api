using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Nome { get; set; } = string.Empty; 
        public string Descricao { get; set; } = string.Empty; 
        
        public List<RecipeIngredient> Ingredientes { get; set; } = new List<RecipeIngredient>(); 
    }
}
