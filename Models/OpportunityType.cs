using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProyectAntivirusBackend.Models
{
    [Table("opportunity_types")]
    public class OpportunityType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("Category")]
        [Column("categories_id")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category? Categories { get; set; }


        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
    }
}
