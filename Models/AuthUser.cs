// Models/AuthUser.cs
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("auth_users")]
    public class AuthUser
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        // Relación con la tabla users
        public required User User { get; set; }
    }
}
