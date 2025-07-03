using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Column("fullname")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [NotMapped]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [Column("phone")]
        public string? Phone { get; set; }

        [Required]
        [Column("rol")]
        public string Role { get; set; } = "user";

        [Column("registration_date")]
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("birthdate")]
        public DateTime Birthdate { get; set; } = DateTime.UtcNow;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        public Profile? Profile { get; set; }
        public AuthUser? AuthUser { get; set; }
        public List<Favorite> Favorites { get; set; } = new();
        public List<Rating> Ratings { get; set; } = new();
    }
}
