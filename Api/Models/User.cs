// Représente un utilisateur du site
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class User
    {
        public int Id { get; set; } // Identifiant unique de l'utilisateur
        public string? Username { get; set; } // Nom d'utilisateur
        [Required, EmailAddress]
        public string? Email { get; set; } // Adresse email
    }
} 