using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("institutions")]
    public class Institution
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("image")]
        public string Image { get; set; } = string.Empty;

        [Column("link")]
        public string? Link { get; set; }

        [Column("information")]
        public string? Information { get; set; }

    }
}
