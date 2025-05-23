// Représente une commande passée par un utilisateur
namespace Api.Models
{
    public class Order
    {
        public int Id { get; set; } // Identifiant unique de la commande
        public int UserId { get; set; } // Référence à l'utilisateur
        public DateTime OrderDate { get; set; } // Date de la commande
        public List<OrderItem> Items { get; set; } = new(); // Liste des produits commandés
        // Pour simplifier, on pourrait ajouter une liste de produits plus tard
    }
} 