using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("profiles")]
    public class Profile
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("preferences")]
        public string? Preferences { get; set; }

        [Column("biography")]
        public string? Biography { get; set; }

        [Column("profile_image")]
        public string? ProfilePicture { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public required User User { get; set; }
    }
}
