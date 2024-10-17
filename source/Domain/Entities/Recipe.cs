using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public class ReceitaIngrediente
    {
        public Guid Id { get; set; } // Identificador único da receita
        public string Nome { get; set; } = string.Empty; // Nome da receita
        public string Descricao { get; set; } = string.Empty; // Descrição da receita (opcional)
        
        // Lista de ingredientes e suas quantidades
        public List<IngredienteQuantidade> Ingredientes { get; set; } = new List<IngredienteQuantidade>(); 

        public class IngredienteQuantidade
        {
            public Guid IngredienteId { get; set; } // Identificador do ingrediente
            public decimal QuantidadeNecessaria { get; set; } // Quantidade necessária do ingrediente
        }
    }
}
