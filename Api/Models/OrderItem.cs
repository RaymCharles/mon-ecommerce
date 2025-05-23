// Représente un produit dans une commande (avec quantité)
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class OrderItem
    {
        public int Id { get; set; } // Identifiant unique de l'item
        [Required]
        public int OrderId { get; set; } // Référence à la commande
        [Required]
        public int ProductId { get; set; } // Référence au produit
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; } // Quantité de ce produit dans la commande
        public Product? Product { get; set; } // Navigation vers le produit
    }
} 