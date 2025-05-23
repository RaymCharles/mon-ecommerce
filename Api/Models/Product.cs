// Représente un produit du catalogue
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        public int Id { get; set; } // Identifiant unique du produit
        [Required]
        public string? Name { get; set; } // Nom du produit
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; } // Prix du produit
        public string? Image { get; set; } // URL de l'image du produit
        public string? Category { get; set; } // Catégorie du produit (vetement, chaussure, etc.)
    }
}
