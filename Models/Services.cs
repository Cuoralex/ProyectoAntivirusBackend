using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("services")]
    public class Service
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey("ServiceType")]
        [Column("service_type_id")]
        public int ServiceTypeId { get; set; }

        public ServiceType? ServiceType { get; set; } = null!;

        [Required]
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("image")]
        public string Image { get; set; } = string.Empty;
    }
}
