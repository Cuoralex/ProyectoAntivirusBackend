using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectAntivirusBackend.Models
{
    [Table("requests")]
    public class Request
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [Required]
        [ForeignKey("Opportunity")]
        [Column("opportunity_id")]
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; } = null!;

        [Required]
        [Column("state")]
        public string State { get; set; } = "pendiente";

        [Column("request_date")]
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    }
}
