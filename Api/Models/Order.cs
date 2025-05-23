namespace Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        // Pour simplifier, on pourrait ajouter une liste de produits plus tard
    }
} 