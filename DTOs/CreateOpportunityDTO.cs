namespace ProyectAntivirusBackend.DTOs
{
    public class CreateOpportunityDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string Requirements { get; set; } = string.Empty;
        public string Benefits { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public required int OpportunityTypeId { get; set; }
        public string? OpportunityTypeName { get; set; }
        public required int InstitutionId { get; set; }
        public string? InstitutionName { get; set; }
        public string? InstitutionImage { get; set; }
        public string? InstitutionLink { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public required int LocalityId { get; set; }
        public string? LocalityCity { get; set; }
        public string Status { get; set; } = "abierta";
        public required string Modality { get; set; }
        public required int RatingId { get; set; }
    }
}