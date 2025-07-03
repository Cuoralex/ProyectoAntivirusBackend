using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{

    public class Rating
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int? UserId { get; set; }

        [ForeignKey("Opportunity")]
        [Column("opportunity_id")]
        public int OpportunityId { get; set; }
        public Opportunity? Opportunity { get; set; }

        [Required]
        [Column("score")]
        public required double Score { get; set; }
    
        [Column("comment")]
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
