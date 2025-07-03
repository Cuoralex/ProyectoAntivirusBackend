namespace ProyectAntivirusBackend.DTOs
{
    public class OpportunityDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int OpportunityTypeId { get; set; }
        public string? OpportunityTypeName { get; set; }
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public int LocalityId { get; set; }
        public string? LocalityCity { get; set; }
        public string Requirements { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public required string Modality { get; set; }
        public DateTime PublicationDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpirationDate { get; set; } = DateTime.UtcNow;
        public int InstitutionId { get; set; }
        public string? InstitutionName { get; set; }
        public string? InstitutionImage { get; set; }
        public string? InstitutionLink { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string Status { get; set; } = "abierta";
        public required int RatingId { get; set; }

    }
}