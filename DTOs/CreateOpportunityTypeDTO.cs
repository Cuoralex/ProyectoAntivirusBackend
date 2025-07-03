using System.ComponentModel.DataAnnotations;

public class CreateOpportunityTypeDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
