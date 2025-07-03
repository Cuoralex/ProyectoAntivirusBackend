using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("localities")]
    public class Locality
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("country")]
        [MaxLength(255)]
        public string Country { get; set; } = string.Empty;

        [Required]
        [Column("state")]
        public string State { get; set; } = string.Empty;

        [Required]
        [Column("city")]
        public string City { get; set; } = string.Empty;
    }
}
